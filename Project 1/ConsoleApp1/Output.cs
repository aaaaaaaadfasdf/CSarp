using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using NumSharp;

public partial class Creature
{
    public delegate void IntAction(int value);

    public List<IntAction> output = [];

    public void OutputCons()
    {
        output = new List<IntAction>
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW,
            MakeChild,
        };
        // has to be at the end of the list!!!!
        for (int i = 0; i < remember.Count; i++)
        {
            output.Add(RememberOutPos);
            output.Add(RememberOutNeg);
        }

    }

    public void RememberOutPos(int index)
    {

        // so that it resets after each round
        if (rememberCounter >= remember.Count)
        {
            rememberCounter = 0;
        }

        remember[rememberCounter] = actVec[index];

    }

    public void RememberOutNeg(int index)
    {

        // so that it resets after each round
        if (rememberCounter >= remember.Count)
        {
            rememberCounter = 0;
        }

        remember[rememberCounter] = -actVec[index];

    }

    public void DirectionN(int index)
    {
        int xx = 1;
        int yy = 0;


        Direction(xx, yy);

    }

    public void DirectionO(int index)
    {
        int xx = 0;
        int yy = 1;

        Direction(xx, yy);
    }

    public void DirectionS(int index)
    {
        int xx = -1;
        int yy = 0;

        Direction(xx, yy);

    }

    public void DirectionW(int index)
    {
        int xx = 0;
        int yy = -1;
        Direction(xx, yy);


    }

    // This Fuction is not part of Output list!!!
    public void Direction(int xx, int yy)
    {

        if (!(x + xx < 0 || y + yy < 0 || x + xx >= Grid.x || y + yy >= Grid.y))
        {
            if (!(Grid.Map[x + xx, y + yy] == Grid.block))
            {
                x += xx;
                y += yy;
                Grid.Map[x,y] = Grid.steptOn;
                iFrames=true;

            }

        }

    }


    public void MakeChild(int index)
    {

        if (food < minimumFoodRequirement) { return; }

        // to make an istance and not just a refrenc
        Creature childCrea = new()
        {
            x = x,
            y = y
        };

        Direction(r.Next(0,2)-r.Next(0,2), r.Next(0,2)-r.Next(0,2));



        for (int i = 0; i < inputNetwork.RowCount; i++)
        {
            for (int j = 0; j < inputNetwork.ColumnCount; j++)
            {
                childCrea.inputNetwork[i, j] = inputNetwork[i, j];
            }
        }

        // get the network
        for (int i = 0; i < network.Count; i++)
        {


            for (int j = 0; j < network[i].RowCount; j++)
            {
                for (int k = 0; k < network[i].ColumnCount; k++)
                {
                    childCrea.network[i][j, k] = network[i][j, k];
                }
            }
        }


        // get the output
        for (int i = 0; i < outputNetwork.RowCount; i++)
        {
            for (int j = 0; j < outputNetwork.ColumnCount; j++)
            {
                childCrea.outputNetwork[i, j] = outputNetwork[i, j];
            }
        }

        food /= 2;
        childCrea.food = food;
        // Mutate
        childCrea.MutateBrain();
        Control.data.Add(childCrea);



    }




}

