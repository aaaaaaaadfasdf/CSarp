

using MathNet.Numerics.LinearAlgebra;
using System.Reflection;
 static partial class   Control
{

    
    public static string MatrixToString(Matrix<float> matrix)
    {
        string str = "";

        for (int i = 0; i < matrix.RowCount; i++)
        {

            for (int j = 0; j < matrix.ColumnCount; j++)
            {

                str += matrix[i, j].ToString() + " ";
            }
        }




        return str;

    }
    
    public static void  SaveSurvival(int generationEnd, float averageX){

        string filePath = Path.Combine(folderDirectory,"Survival.txt");

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            // File doesn't exist, create it
            using (FileStream fs = File.Create(filePath))
            {
                            
                            
            }

        }
      

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine($"Generation {generationCount} of {generationEnd},  average x position {averageX} ");

        }
    }
public static List<Creature> PullPositions(int gen, int step,List<Creature> upData){

        
        
        string filePath = Path.Combine(folderDirectory,"Gen"+gen,"Step"+step+".txt");


        try
        {
             
           
            

            
          
                 // Read all lines from the file into an array
                string[] lines = File.ReadAllLines(filePath);

            
                for(int i =0,j=0;j<lines.Length;){
                
                    // get the position
                     upData[i].x= int.Parse(lines[j].Split(' ')[0]);
                     upData[i].y= int.Parse(lines[j+1].Split(' ')[0]);
                     
                     i+=1;
                     j+=2;

                }
             
            
        return upData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return data;
        }
    

        
}
public static List<Creature> PullData(int gen){ 

        

        List<Creature> dataFromFile= [];

        string filePath = Path.Combine(folderDirectory,"Gen"+gen,"data.txt");
      

  
                       // Read all lines from the file into an array
                string[] lines = File.ReadAllLines(filePath);

            
                for(int i =0;i<lines.Length;){
                Creature cre = new();
                    // get the position
                     
                     
                     // get the ImputNetwork
                     List<float> arr;
                     string[] str = lines[i].Split(' ');
                    for(int j=0;j<cre.inputNetwork.RowCount;j++){
                          for(int k=0;k<cre.inputNetwork.ColumnCount;k++){
                        cre.inputNetwork[j,k]= float.Parse(str[j*cre.inputNetwork.ColumnCount+k]);
                        }
                    }
                    
                    // get the network
                    for(int j=0;j<cre.network.Count;j++){
                        
                      str = lines[i+j+1].Split(' ');
                         for(int k=0;k<cre.network[j].RowCount;k++){
                          for(int l=0;l<cre.network[j].ColumnCount;l++){
                        cre.network[j][k,l]= float.Parse(str[k*cre.network[j].ColumnCount+l]);
                    }
                    }
                    }


                    // get the output

                   
                      str = lines[i+1+cre.network.Count].Split(' ');
                    for(int j=0;j<cre.outputNetwork.RowCount;j++){
                          for(int k=0;k<cre.outputNetwork.ColumnCount;k++){
                        cre.outputNetwork[j,k]= float.Parse(str[j*cre.outputNetwork.ColumnCount+k]);
                    }
                    }

                    // this is done to move to the next location where the next creatur is stored
                    i+=1+cre.network.Count+1;


                    dataFromFile.Add(cre);



                }
             
            

        try
        {
             
           
          

            
          
        return dataFromFile;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: in get data try");
            return data;
        }
    

        
    }
    public static void MakeRunFolder()
    {



        // Specify the path of the folder you want to create when no Folder is given.
        if(!Directory.Exists(folderDirectory)){
            
        folderDirectory =Path.Combine(mainDirectory + $"\\{currentTime:yyyyMMdd_HHmmss}");
        
        
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
    
    }
    public static void MakeGenFolder()
    {

        string folderPath =Path.Combine(folderDirectory , $"Gen{generationCount}");

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
    public static void PushGenData(){
         string fileName = $"data.txt";

        // Set the path where you want to save the file
        string path = Path.Combine(folderDirectory , $"Gen{generationCount}", fileName);

        // Write some content to the file

        try
        {

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < data.Count; i++)
                {


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
    public static void SaveStep()
    {

        string fileName = $"Step{stepCount}.txt";

        // Set the path where you want to save the file
        string path = Path.Combine(folderDirectory , $"Gen{generationCount}", fileName);

        // Write some content to the file




        try
        {

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < data.Count; i++)
                {


                    writer.WriteLine(data[i].x.ToString());
                    writer.WriteLine(data[i].y.ToString());

                    




                }

            }



        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
static void Animate(int AniGen){
            System.Windows.Forms.Application.EnableVisualStyles();     
            System.Windows.Forms.Application.Run(new AnimatGen(AniGen));
      
}

}