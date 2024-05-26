
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using ILNumerics.F2NET.Formatting;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OpenTK.Graphics.ES11;


static partial class Control
{
    public const int sizex = 500;
    public const int sizey = 500;
    public const int pop = 10;
    public const int gridx = 100;
    public const int gridy = 100;
    public static int generationLength = 100;
    public static List<Creature> Storedata = [];
    static int generationCount = 0;
    public static int stepCount = 0;

     








    public static  string folderDirectory;
    static readonly DateTime currentTime = DateTime.Now;






    public static List<Creature> data = [];

    public static List<int> saveData = [];

    public static string mainDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFolder");

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


        // Run it for as manny generations as the user says
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




        // Run Gen
        while (stepCount < generationLength)
        {

            // Pass where the Creaturs are to the Map
            for (int i = 0; i < data.Count; i++)
            {
                Grid.Map[data[i].x, data[i].y] = Grid.creatur;

            }

            SaveStep();
            for (int i = 0; i < data.Count; i++)
            {
                data[i].RunBrain();

            }

            // Kill all Creatures that are on a steptOn field and have not moved;
            for (int i = 0; i < data.Count; i++)
            {
                if (Grid.Map[data[i].x, data[i].y] == Grid.steptOn && !data[i].iFrames)
                {
                    Grid.Map[data[i].x, data[i].y] = Grid.food;
                    data.RemoveAt(i);
                }

            }

            // let all creatures that are on a food field gain food
            for (int i = 0; i < data.Count; i++)
            {
                if (Grid.Map[data[i].x, data[i].y] == Grid.food)
                {
                    data[i].food += Creature.gainFoodFromCreatur;
                }

            }

            // delet all food
            for (int i = 0; i < data.Count; i++)
            {
                if (Grid.Map[data[i].x, data[i].y] == Grid.food)
                {
                    Grid.Map[data[i].x, data[i].y] = Grid.creatur;
                }

                // Remove i Frames 
                data[i].iFrames=false;

            }




            stepCount += 1;

        }
        stepCount = 0;









        // Push the calculated Data
        PushGenData();




        Console.WriteLine($"Generation {generationCount} of {generationEnd},  Population {data.Count} ");
        SaveSurvival(generationEnd, data.Count);


    }

    public static void RunStep()
    {




    }





}

