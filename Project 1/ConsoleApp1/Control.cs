
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using ILNumerics.F2NET.Formatting;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.CodeAnalysis.CSharp.Syntax;


static partial class Control
{
    public const int sizex = 5000;
    public const int sizey = 1000;
    public const int pop = 1000;
    public const int gridx = 500;
    public const int gridy = 100;
    public static int generationLength = 100;
    public static List<Creature> Storedata = [];
    static int generationCount = 0;
    public static int stepCount = 0;








    public static string folderDirectory;
    static readonly DateTime currentTime = DateTime.Now;






    public static List<Creature> data = [];

    public static List<int> saveData = [];

    public static string mainDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"SaveFolder");

    static Random r = new();


    public static void Setup()
    {

        Grid.MakeGrid();
        // Add Creaturs
        for (int i = 0; i < pop; i++)
        {
            data.Add(new Creature());
        }

    }
    static void Run(int generationEnd)
    {


        MakeRunFolder();

        for (int i = 0; true; i++)
        {
            // get the current Generation
            if (!Directory.Exists(Path.Combine(folderDirectory, $"Gen{i}")))

            {

                //get the current generation
                generationCount = i;
                // get the current data
                if (generationCount != 0)
                {
                    data = PullData(i - 1);
                    Console.WriteLine($"got data from Gen {i - 1}");
                }
                else
                {
                    Console.WriteLine($"New Run");
                }
                break;


            }


        }

        stepCount = 0;
        generationEnd += generationCount;
        while (generationCount < generationEnd)
        {


            MakeGen(generationLength, generationEnd);
            generationCount += 1;

        }


    }
    public static void MakeGen(int generationLength, int generationEnd)
    {

        // chek if two intances are the same, this can be left out if non are ever
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = i + 1; j < data.Count; j++)
            {
                if (ReferenceEquals(data[i], data[j]))
                {
                    Console.WriteLine($"Warning data[{i}] and data[{j}] are references to the same object!!.");
                }

            }
        }
        //Make a Folder to Store Data
        MakeGenFolder();


        // Randomly distribiute
        for (int i = 0; i < data.Count; i++)
        {
            data[i].x = r.Next(Grid.x / 100);
            data[i].y = r.Next(Grid.y);
        }


        // Run Gen
        while (stepCount < generationLength)
        {
            SaveStep();
            for (int j = 0; j < pop; j++)
            {
                data[j].RunBrain();



            }
            stepCount += 1;

        }
        stepCount = 0;



        // look condition

        float averageX = 0;
        int median = 0;

        // find out where the average lies
        for (int i = 0; i < data.Count; i++)
        {
            averageX += data[i].x;
        }
        averageX /= (float)data.Count;
        // splice out the bader haf
        while (data.Count > pop / 2)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].x < data[median].x)
                {
                    median = i;
                }
            }
            data.RemoveAt(median);
            median =0;

        }


        float survived = data.Count / (float)pop * 100;



        // fill up with children
        saveData.Clear();
        for (int i = 0; i < data.Count; i++)
        {
            saveData.Add(i);
        }

        while (pop > data.Count)
        {
            if (saveData.Count == 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    saveData.Add(i);
                }
            }
            // so that every gets equal children and its not just random
            // to make an istance and not just a refrenc
            Creature creCopy = new();
            int selectRan = r.Next(0, saveData.Count);
            Creature getCre = data[saveData[selectRan]];
            saveData.RemoveAt(selectRan);
            creCopy.x = getCre.x;
            creCopy.y = getCre.y;



            for (int i = 0; i < getCre.inputNetwork.RowCount; i++)
            {
                for (int j = 0; j < getCre.inputNetwork.ColumnCount; j++)
                {
                    creCopy.inputNetwork[i, j] = getCre.inputNetwork[i, j];
                }
            }

            // get the network
            for (int i = 0; i < getCre.network.Count; i++)
            {


                for (int j = 0; j < getCre.network[i].RowCount; j++)
                {
                    for (int k = 0; k < getCre.network[i].ColumnCount; k++)
                    {
                        creCopy.network[i][j, k] = getCre.network[i][j, k];
                    }
                }
            }


            // get the output
            for (int i = 0; i < getCre.outputNetwork.RowCount; i++)
            {
                for (int j = 0; j < getCre.outputNetwork.ColumnCount; j++)
                {
                    creCopy.outputNetwork[i, j] = getCre.outputNetwork[i, j];
                }
            }


            // Mutate
            creCopy.MutateBrain();
            data.Add(creCopy);



        }

        // 2 options 1. Mutate everybody or Mutate only children
        for (int i = 0; i < data.Count; i++)
        {
            //data[i].MutateBrain();
        }


        // set all remember neurons to 0
        for (int i = 0; i < data.Count; i++)
        {

            for (int j = 0; j < data[i].remember.Count; j++)
            {
                data[i].remember[j] = 0;

            }



        }

        // Push the calculated Data
        PushGenData();




        Console.WriteLine($"Generation {generationCount} of {generationEnd},  average x position {averageX} ");
        SaveSurvival( generationEnd,  averageX);


    }



}

