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


NDArray imputVektor ;
    NDArray imputNetwork ;



        NDArray network ;
    NDArray outputNetwork ;


   









    





    public Creatur()
    {
       

        x = CreProp.r.Next(0, Grid.x);
        y = CreProp.r.Next(0, Grid.y);
       

       Random r = new Random();


         imputNetwork = np.random.rand(CreProp.neuronsPerLayer, CreProp.hiddenLayers);

        for ( int i =0; i< imputNetwork.shape[0]; i++){
            for ( int j =0; j< imputNetwork.shape[1]; j++){
                imputNetwork[i][j] = (float)Math.Round(r.NextDouble())*r.NextDouble();
            }
        }

        
network = np.random.rand(CreProp.neuronsPerLayer, CreProp.hiddenLayers);

        for ( int i =0; i< network.shape[0]; i++){
            for ( int j =0; j< network.shape[1]; j++){
                network[i][j] = (float)Math.Round(r.NextDouble())*r.NextDouble();
            }
        }



    }

    public void MakeBrain()
    {

       
         


    }

public Creatur RunBrain(){

    

     
 Creatur StoreCreatur = this;
     


     return StoreCreatur;
    
}





}


