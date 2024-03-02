

using MathNet.Numerics.LinearAlgebra;
using System.Reflection;
 static partial class   Control
{

    
    public static string MatrixToString(Matrix<float> matrix)
    {
        string str = "";
        for (int i = 0; i < matrix.RowCount; i++)
        {

            for (int j = 0; j < matrix.RowCount; j++)
            {

                str += matrix[i, j].ToString() + " ";
            }
        }




        return str;

    }
    static bool TryParseFunctionCall(string input, out string functionName, out object[] arguments)
    {
        functionName = null;
        arguments = null;

        try
        {
            // Remove any whitespace and split the input into function name and arguments
            input = input.Replace(" ", "");
            int openParenIndex = input.IndexOf('(');
            int closeParenIndex = input.LastIndexOf(')');

            functionName = input.Substring(0, openParenIndex);
            string argumentsStr = input.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1);
            string[] args = argumentsStr.Split(',');

            arguments = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                arguments[i] = int.Parse(args[i]); // Assuming all arguments are integers for simplicity
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
    static void InvokeFunction(string functionName, object[] arguments)
    {
        try
        {
            // Get the method info of the function
            MethodInfo methodInfo = typeof(Control).GetMethod(functionName, BindingFlags.Static | BindingFlags.NonPublic);

            // Invoke the method with the provided arguments
            if (methodInfo != null)
            {
                methodInfo.Invoke(null, arguments);
            }
            else
            {
                Console.WriteLine($"Function '{functionName}' not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing function '{functionName}': {ex.Message}");
        }
    }

    // Example function to be invoked dynamically

    static void myfunction(int a, int b)
    {
        Console.WriteLine($"myfunction({a}, {b}) called. Sum: {a + b}");
    }

    public static List<Creatur> GetDataFromFile(int gen, int step){

        

        List<Creatur> dataFromFile= [];

        string filePath = folderDirectory+"Gen"+gen+"//Step"+step+".txt";
      

        try
        {
             
           
            

            
          
                 // Read all lines from the file into an array
                string[] lines = File.ReadAllLines(filePath);

            
                for(int i =0;i<lines.Length;){
                Creatur cre = new();
                    // get the position
                     cre.x= int.Parse(lines[i].Split(' ')[0]);
                     cre.y= int.Parse(lines[i+1].Split(' ')[0]);
                     
                     // get the ImputNetwork
                     List<float> arr;
                     string[] str = lines[i+2].Split(' ');
                    for(int j=0;j<cre.inputNetwork.RowCount;j++){
                          for(int k=0;k<cre.inputNetwork.ColumnCount;k++){
                        cre.inputNetwork[j,k]= float.Parse(str[j+k]);
                        }
                    }
                    
                    // get the network
                    for(int j=0;j<cre.network.Count;j++){
                        
                      str = lines[i+j+3].Split(' ');
                         for(int k=0;k<cre.network[j].RowCount;k++){
                          for(int l=0;l<cre.network[j].ColumnCount;l++){
                        cre.network[j][k,l]= float.Parse(str[k+l]);
                    }
                    }
                    }


                    // get the output

                   
                      str = lines[i+3+cre.network.Count].Split(' ');
                    for(int j=0;j<cre.outputNetwork.RowCount;j++){
                          for(int k=0;k<cre.outputNetwork.ColumnCount;k++){
                        cre.outputNetwork[j,k]= float.Parse(str[j+k]);
                    }
                    }

                    // this is done to move to the next location where the next creatur is stored
                    i+=3+cre.network.Count+1;


                    dataFromFile.Add(cre);



                }
             
            
        return dataFromFile;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return data;
        }
    

        
    }

        public static void SaveThisRun()
    {



        // Specify the path of the folder you want to create

        folderDirectory = mainDirectory + $"\\{currentTime:yyyyMMdd_HHmmss}\\";
        string folderPath = folderDirectory;

        try
        {
            // Attempt to create the directory
            Directory.CreateDirectory(folderPath);


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static void SaveGen()
    {

        string folderPath = folderDirectory + $"Gen{generationCount}\\";

        try
        {
            // Attempt to create the directory
            Directory.CreateDirectory(folderPath);


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static void SaveStep()
    {

        string fileName = $"Step{stepCount}.txt";

        // Set the path where you want to save the file
        string path = Path.Combine(folderDirectory + $"Gen{generationCount}", fileName);

        // Write some content to the file




        try
        {

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < data.Count; i++)
                {


                    writer.WriteLine(data[i].x.ToString());
                    writer.WriteLine(data[i].y.ToString());

                    writer.WriteLine(MatrixToString(data[i].inputNetwork));



                    for (int j = 0; j < data[i].network.Count; j++)
                    {
                        writer.WriteLine(MatrixToString(data[i].network[j]));
                    }
                    writer.WriteLine(MatrixToString(data[i].outputNetwork));




                }

            }



        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }



static void AnimatGen(int AniGen){
            System.Windows.Forms.Application.EnableVisualStyles();     
            System.Windows.Forms.Application.Run(new AnimatGen(AniGen));
      
}

}