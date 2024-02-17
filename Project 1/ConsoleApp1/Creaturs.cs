using Microsoft.VisualBasic;
using NumSharp;
using MathNet.Numerics.LinearAlgebra;

struct CreProp
{
    public static List<Creatur> data = [];
}

public partial struct Creatur
{
    public int x = 100;
    public int y = 100;

    NDArray inputNetwork;
    NDArray network;
    NDArray outputNetwork;

    NDArray actVec;

    // consts

    public const int Pop = 100;
    public const int bias = 1;

    public const int inputNeuron = 0;

    public const int outputNeuron = 2;

    public const int neuronsPerLayer = 3;
    public const int hiddenLayers = 3;

    public Creatur()
    {
        Random r = new Random();

        x = r.Next(0, Grid.x);
        y = r.Next(0, Grid.y);


    var M = Matrix<double>.Build;
    var V = Vector<double>.Build;

    // build the same as above
    var inp = M.Dense(3, 10,(i,j)=>  Math.Round(r.NextDouble())*r.NextDouble() );
    for(int i = 0; i<inp.RowCount;i++){
    inp[i, inp.ColumnCount-1]=5;
    }
    var v = V.Random(10);
  
    var g = inp.Multiply(v);
    





        InputCons();
        OutputCons();


        MakeBrain();






    }

    public void MakeBrain()
    {
        Random r = new Random();

        inputNetwork = np.random.rand(neuronsPerLayer, input.Count + bias);

        for (int i = 0; i < inputNetwork.shape[0]; i++)
        {
            for (int j = 0; j < inputNetwork.shape[1]; j++)
            {
                if (j == inputNetwork.shape[1] - 1)
                {
                    inputNetwork[i][j] = 5; //(float)Math.Round(r.NextDouble())*r.NextDouble();;
                }
                else
                {
                    inputNetwork[i][j] = (float)Math.Round(r.NextDouble()) * r.NextDouble();
                }
            }
        }

        network = np.random.rand(hiddenLayers, neuronsPerLayer, neuronsPerLayer + bias);

        for (int i = 0; i < network.shape[0]; i++)
        {
            for (int j = 0; j < network.shape[1]; j++)
            {
                for (int k = 0; k < network.shape[2]; k++)
                {
                    if (k == network.shape[2] - 1)
                    {
                        network[i][j][k] = 5; //(float)Math.Round(r.NextDouble())*r.NextDouble();;
                    }
                    else
                    {
                        network[i][j][k] = (float)Math.Round(r.NextDouble()) * r.NextDouble();
                    }
                }
            }
        }

        outputNetwork = np.random.rand(output.Count, neuronsPerLayer + bias);

        for (int i = 0; i < outputNetwork.shape[0]; i++)
        {
            for (int j = 0; j < outputNetwork.shape[1]; j++)
            {
                if (j == outputNetwork.shape[1] - 1)
                {
                    outputNetwork[i][j] = 5; //(float)Math.Round(r.NextDouble())*r.NextDouble();;
                }
                else
                {
                    outputNetwork[i][j] = (float)Math.Round(r.NextDouble()) * r.NextDouble();
                }
            }
        }
    }

    public void RunBrain()
    {
        actVec = np.random.rand(input.Count + bias);
        for (int i = 0; i < input.Count; i++)
        {
            if (i == actVec.shape[0] - 1)
            {
                actVec = 1.0;
            }
            else
            {
                actVec[i]=input[i]();
            }
        }

        
    }
}
