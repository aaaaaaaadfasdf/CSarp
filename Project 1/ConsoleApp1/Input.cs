
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Linq.Expressions;



using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Reflection.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;


public partial class Creature
{

    public delegate void MyMethodDelegate();

    public List<Func<float>> input = [];

    public void InputCons()
    {
        input = new List<Func<float>>
        {
            ImpDirectionN,
            ImpDirectionO,
            ImpDirectionS,
            ImpDirectionW,
            X,
            Y,
      
     


        };



        for (int i = 0; i < remember.Count; i++)
        {
           input.Add(RememberInp);
        }

    }

public float Random(){
    return (float)(r.NextDouble());
}

  public float X(){
  return 1.0f/x;
  }

    public float Y(){
  return 1.0f/y;
  }

    public float RememberInp()
    {

        // so that it resets after each round
        if (rememberCounter >= remember.Count)
        {
            rememberCounter = 0;
        }

        float val = remember[rememberCounter];
        rememberCounter += 1;
        return val;
    }



    public float ImpDirectionN()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (x + c >= Grid.x)
            {
                return (float)1 / c;
            }
            if (Grid.Map[x + c, y] == Grid.block)
            {
                return (float)1 / c;
            }
        }
    }
    public float ImpDirectionO()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (y + c >= Grid.y)
            {
                return (float)1 / c;
            }
            if (Grid.Map[x, y + c] == Grid.block)
            {
                return (float)1 / c;
            }
        }
    }
    public float ImpDirectionS()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (x - c < 0)
            {
                return (float)1 / c;
            }
            if (Grid.Map[x - c, y] == Grid.block)
            {
                return (float)1 / c;
            }
        }
    }
    public float ImpDirectionW()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (y - c < 0)
            {
                return 1 / c;
            }
            if (Grid.Map[x, y - c] == Grid.block)
            {
                return (float)1 / c;
            }
        }
    }





    public float ImpTime()
    {
        return (float)1 / (Control.stepCount + 1);
    }


public float  Sicle(){
    return (float)1 / (Control.stepCount%50 + 1);
}






}


