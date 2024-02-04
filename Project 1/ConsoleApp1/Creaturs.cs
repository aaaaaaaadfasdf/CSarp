using Microsoft.VisualBasic;
using NumSharp;
struct CreProp
{   

    public static Random r = new Random();
    public const int Pop = 100;

    public static List<Creatur> data = [];

  

    

    public const  int imputNeuron = 0;
   
    public const int outputNeuron = 2;


    public const int neuronsPerLayer = 3;
    public const int hiddenLayers =3;

    
    
}


struct Creatur
{
    public int x = 100;
    public int y = 100;



    NDArray imputNetwork ;
        NDArray network ;
    NDArray outputNetwork ;


   









    





    public Creatur()
    {
       

        x = CreProp.r.Next(0, Grid.x);
        y = CreProp.r.Next(0, Grid.y);
       

       Random r = new Random();


         imputNetwork = np.arange(r.Next(0,2)*r.NextDouble()).reshape(MainProgram.imput.imput.Count,CreProp.neuronsPerLayer);
         network =  np.arange(r.Next(0,2)*r.NextDouble()).reshape(0,10,3);
         outputNetwork = np.arange(r.Next(0,2)*r.NextDouble()).reshape(CreProp.neuronsPerLayer,MainProgram.output.output.Count);


    
        
            MakeBrain();




    }

    public void MakeBrain()
    {

       
         


    }

public Creatur RunBrain(){

    

     
 Creatur StoreCreatur = this;
     


     return StoreCreatur;
    
}





}


