using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using NumSharp;

public partial class Creature
{
    public delegate void IntAction(int value);
    
    public  List<IntAction> output = [];

    public void OutputCons()
    {
        output = new List<IntAction>
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW
        };
        // has to be at the end of the list!!!!
        for(int i=0;i<remember.Count;i++){
            output.Add(RememberOutPos);
            output.Add(RememberOutNeg);
        }
        
    }

    public void RememberOutPos(int index){

        // so that it resets after each round
        if(rememberCounter >= remember.Count){
            rememberCounter =0;
        }

        remember[rememberCounter]= actVec[index];
        
    }

        public void RememberOutNeg(int index){

        // so that it resets after each round
        if(rememberCounter >= remember.Count){
            rememberCounter =0;
        }

        remember[rememberCounter]= -actVec[index];
        
    }





    public  void DirectionN(int index)
        {
            int xx = 1;
            int yy = 0;

            if (!( x + xx < 0 ||  y + yy < 0 ||  x + xx >= Grid.x ||  y + yy >= Grid.y))
            {
                if (Grid.Map[ x + xx,  y + yy] == 0)
                {
                     x += 1;
                }
            }
          
        }

        public  void DirectionO(int index)
        {
            int xx = 0;
            int yy = 1;

            if (!( x + xx < 0 ||  y + yy < 0 ||  x + xx >= Grid.x ||  y + yy >= Grid.y))
            {
                if (Grid.Map[ x + xx,  y + yy] == 0)
                {
                     y += 1;
                }
            }
          
        }

        public void  DirectionS(int index)
        {
            int xx = -1;
            int yy = 0;

            if (!( x + xx < 0 ||  y + yy < 0 ||  x + xx >= Grid.x ||  y + yy >= Grid.y))
            {
                if (Grid.Map[ x + xx,  y + yy] == 0)
                {
                     x += -1;
                }
            }
           
        }

        public  void DirectionW(int index)
        {
            int xx = 0;
            int yy = -1;

            if (!( x + xx < 0 ||  y + yy < 0 ||  x + xx >= Grid.x ||  y + yy >= Grid.y))
            {
                if (Grid.Map[ x + xx,  y + yy] == 0)
                {
                     y -= 1;
                }
            }
          
        }
    
    
 
    
    
    
    
    }

