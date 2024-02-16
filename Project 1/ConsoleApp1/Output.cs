using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using NumSharp;

partial struct Creatur
{
    public  List<Action> output = [];

    public void OutputCons()
    {
        output = new List<Action>
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW
        };
    }


        public  void DirectionN()
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

        public  void DirectionO()
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

        public void  DirectionS()
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

        public  void DirectionW()
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

