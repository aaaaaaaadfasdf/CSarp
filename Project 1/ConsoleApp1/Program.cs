
using System.Globalization;
using System.Reflection;
using MathNet.Numerics.LinearAlgebra;


 static partial class Control
{
    public const int size = 800;
    public const int pop = 1000;
    public const int gridx = 100;
    public const int gridy = 100;

    static int generationCount = 0;
    static int stepCount = 0;

    public static int generationLength = 100;



    public static string folderDirectory;
    static readonly DateTime currentTime = DateTime.Now;





    
    public static List<Creatur> data = [];



    public static string mainDirectory = "C:\\Users\\jonat\\OneDrive - SBL\\Desktop\\SaveFolder";//"C:\\Users\\jonat\\OneDrive - SBL\\Dokumente\\SaveFolder";// AppDomain.CurrentDomain.BaseDirectory;

    static Random r = new();


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MyProgram!");
        Setup();

        while (true)
        {
            Console.Write("Enter a function call (e.g., myfunction(1, 4)): ");
            string input = Console.ReadLine();

            // Parse the function call
            if (TryParseFunctionCall(input, out string functionName, out object[] arguments))
            {
                // Invoke the function dynamically
                InvokeFunction(functionName, arguments);
            }
            else
            {
                Console.WriteLine("Invalid function call. Try again.");
            }
        }
    }

    public static void Setup()
    {

        Grid.MakeGrid();
        // Add Creaturs
        for (int i = 0; i < pop; i++)
        {
            data.Add(new Creatur());
        }

    }

    static void Run( int generationEnd)
    {

        // to make shure that all the count variables are set to 0
        generationCount =0;
        stepCount = 0;
        

        SaveThisRun();

        while (generationCount < generationEnd)
        {
            

            MakeGen(generationLength, generationEnd);
            generationCount += 1;
          
        }
        generationCount = 0;

    }
    public static void MakeGen(int generationLength, int generationEnd)
    {
        

        //Make a Folder to Store Data
        SaveGen();
        // Randomly distribiute
        for (int i = 0; i < data.Count; i++)
        {
            data[i].x = r.Next(Grid.x);
            data[i].y = r.Next(Grid.y);
        }
        if (true)
        {
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

        }

        // look condition
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].x < Grid.x / 2)
            {
                data.RemoveAt(i);
            }
        }
        // fill up
        while (pop > data.Count)
        {
            data.Add(data[r.Next(data.Count)]);
        }

        //ramdomize position
        for (int i = 0; i < pop; i++)
        {
            data[i].MutateBrain();
        }
        Console.WriteLine(generationCount + " of " + generationEnd);



    }

}

