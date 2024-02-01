struct CreProp
{   

     public static Random r = new Random();
    public const int Pop = 100;

    public static List<Creatur> data = [];

    public const int linkNum = 4;

    public const int innerNurNumb = 3;

    public const  int imputNeuron = 0;
    public const int innerNeuron = 1;
    public const int outputNeuron = 2;
}


struct Creatur
{
    public int x = 100;
    public int y = 100;



    public List<Link> linksProto = []; // Not used linkes have to be spliced, because of that it is a prototyp;
    public List<Link> links = [];

    public List<float> innerNeurons = [];

    public List<float> innerNeuronsStore = [];

    public List<float> outputNeurons = [];

    public List<float> outputNeuronsStore = [];





    





    public Creatur()
    {
       

        x = CreProp.r.Next(0, Grid.x);
        y = CreProp.r.Next(0, Grid.y);
        Console.Write("d");


    
        
            MakeBrain();




    }

    public void MakeBrain()
    {

       
          for (int i = 0; i < CreProp.innerNurNumb; i++)
        {
            innerNeurons.Add((float)CreProp.r.NextDouble());

        }
        innerNeuronsStore =innerNeurons;

        for (int i = 0; i < MainProgram.output.output.Count; i++)
        {
            outputNeurons.Add((float)CreProp.r.NextDouble());
        }
        outputNeuronsStore = outputNeurons;







        for (int i = 0; i < CreProp.linkNum; i++)
        {

            linksProto.Add(new Link());

  
        }


        // now we look that we cut out all of the unused Neurons
      for (int i = 0; i < linksProto.Count; i++)
        {
            if(linksProto[i].to==CreProp.outputNeuron){
                links.Add(linksProto[i]);
                linksProto.RemoveAt(i);  // so that the same link dosent get added 2 times
                i--;
            }

        }


        while(true){
            bool MakeBreak = true;
        for (int i = 0; i < linksProto.Count; i++) // 

        { for (int j = 0; j < links.Count; j++)
        {
            if(linksProto[i].from==links[j].to&&linksProto[i].neurontypeFrom==links[j].neurontypeTo){
                links.Add(linksProto[i]);
                linksProto.RemoveAt(i);  // so that the same link dosent get added 2 times
                i--;
                MakeBreak = false;
                break;
            }
        }
        }
        if(MakeBreak== true){
            break;
        }
}

        links.Reverse();



    }

public void RunBrain(){


     for (int i = 0; i < links.Count; i++){
       
         float imputValue=0 ;
        if(links[i].neurontypeFrom == CreProp.imputNeuron){
            imputValue = MainProgram.imput.imput[links[i].from](this)/5;
        }else  if(links[i].neurontypeFrom == CreProp.innerNeuron){
            imputValue = innerNeurons[links[i].from];
        }


        if(links[i].neurontypeTo == CreProp.innerNeuron){
            innerNeurons[links[i].to] += (float)Math.Tanh( imputValue * links[i].connection);
        }else  if(links[i].neurontypeTo == CreProp.outputNeuron){
            outputNeurons[links[i].to] += (float)Math.Tanh(imputValue*links[i].connection);
        }
     } 
        // chose which outputnurons should fire
     for(int i =0; i<outputNeurons.Count;i++){
        if(0<Math.Tanh(outputNeurons[i])){
           x= MainProgram.output.output[i]( this).x;
            y= MainProgram.output.output[i]( this).y;
        }
     }

     innerNeurons=innerNeuronsStore;
     outputNeurons = outputNeuronsStore;

        
}





}

public struct Link
{
    public int from;
    public int neurontypeFrom; // Neurontype

    public float connection;

    public int to;// Neurontype

    public int neurontypeTo; // Neurontype



    public Link()
    {
       

        int equalINO = CreProp.r.Next(0, 2);// makes so that there are equal numbers of imput internal and output Neurons


        if (equalINO == 0)
        {
            //Imput
            from = CreProp.r.Next(0, MainProgram.imput.imput.Count);
            neurontypeFrom = CreProp.imputNeuron;

        }
        else if (equalINO == 1)
        {
            //Inner Neurons
            from = CreProp.r.Next(0, CreProp.innerNurNumb);
            neurontypeFrom = CreProp.innerNeuron;

        }


        connection = (float)CreProp.r.NextDouble();


        equalINO = CreProp.r.Next(0, 2);

        if (equalINO == 0)
        {
            // Inner Neurons
            to = CreProp.r.Next(0, CreProp.innerNurNumb);
            neurontypeTo = CreProp.innerNeuron;

        }
        else if (equalINO == 2)
        {
            // Autput
            to = CreProp.r.Next(0, MainProgram.output.output.Count);
            neurontypeTo = CreProp.outputNeuron;

        }



    }
}

