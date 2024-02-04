
using NumSharp;
using System.Data;
using System.Security.Cryptography.X509Certificates;

struct Output
{



    public List<Func<Creatur, Creatur>> output = [];



    public Output()
    {

        output = new List<Func<Creatur,Creatur>>
        
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW
        };


    }



    public static Creatur DirectionN(Creatur inc)
    {

        
        
        int x = 1;
        int y = 0;


        if (!(inc.x + x < 0 || inc.y + y < 0 || inc.x + x >= Grid.x || inc.y + y >= Grid.y))
        {

if(Grid.Map[inc.x+x,inc.y+y]==0){

            inc.x += 1;
       }
            


        }
        return inc;





    }


    public static Creatur DirectionO(Creatur inc)
    {

        int x = 0;
        int y = 1;


        if (!(inc.x + x < 0 || inc.y + y < 0 || inc.x + x >= Grid.x || inc.y + y >= Grid.y))
        {

if(Grid.Map[inc.x+x,inc.y+y]==0){

            inc.y += 1;
       }

            


        }
        return inc;
    }

    public static Creatur DirectionS(Creatur inc)
    {
     int x = -1;
     int y = 0;


        if (!(inc.x + x < 0 || inc.y + y < 0 || inc.x + x >= Grid.x || inc.y + y >= Grid.y))
        {
            if(Grid.Map[inc.x+x,inc.y+y]==0){

            inc.x += -1;
       }

            


        }
        return inc;
    }

    public static Creatur DirectionW(Creatur inc)
    {
        int x = 0;
        int y = -1;


        if (!(inc.x + x < 0 || inc.y + y < 0 || inc.x + x >= Grid.x || inc.y + y >= Grid.y))
        {
            if(Grid.Map[inc.x+x,inc.y+y]==0){

            inc.y -= 1;
       }


        }
        return inc;
    }
}

