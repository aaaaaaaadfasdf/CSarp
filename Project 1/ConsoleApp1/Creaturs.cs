using Microsoft.VisualBasic;
using NumSharp;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.CodeAnalysis.CSharp.Syntax;
// All the values are the same ? needs to be fixed


public partial class Creatur
{

    static Random r = new();
    public int x = 100;
    public int y = 100;


    public Matrix<float> inputNetwork;

    public List<Matrix<float>> network = [];

    public Matrix<float> outputNetwork;

    public Vector<float> actVec;

    public Vector<float> valVec;


    // consts

    
    public const int bias = 1;

    public const int inputNeuron = 0;

    public const int outputNeuron = 2;

    public const int neuronsPerLayer = 3;
    public const int hiddenLayers = 3;

    public Creatur()
    {


        x = r.Next(0, Grid.x);
        y = r.Next(0, Grid.y);








        InputCons();
        OutputCons();


        MakeBrain();






    }

    public void MakeBrain()
    {

        //setting up the diffrent Layers of the Network


        inputNetwork = Matrix<float>.Build.Dense(neuronsPerLayer, input.Count + bias);
        inputNetwork = MakeMatrix(inputNetwork);

        //network 
        for (int i = 0; i < hiddenLayers; i++)
        {
            network.Add(Matrix<float>.Build.Dense(neuronsPerLayer, neuronsPerLayer + bias));
        }
        for (int i = 0; i < hiddenLayers; i++)
        {
            network[i] = MakeMatrix(network[i]);
        }






        outputNetwork = Matrix<float>.Build.Dense(output.Count, neuronsPerLayer + bias);
        outputNetwork = MakeMatrix(outputNetwork);





    }


    public Matrix<float> MakeMatrix(Matrix<float> matrix)
    {
        // This function creates a Matrix wher exactly 50% of all the values
        // are 0 and the other 50% are between 1 and -1 
        List<float> list = [];
        for (int i = 0; i < matrix.RowCount * matrix.ColumnCount; i++)
        {
            if (i < matrix.RowCount * matrix.ColumnCount / 2)
            {
                list.Add((float)(r.NextDouble() - 0.5) * 2);
            }
            else
            {
                list.Add(0);
            }
        }


        for (int i = 0; i < matrix.RowCount; i++)
        {
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                int ran = r.Next(list.Count);
                matrix[i, j] = list[ran];
                list.RemoveAt(ran);
            }
        }
        for (int i = 0; i < inputNetwork.RowCount; i++)
        {
            if (matrix[i, matrix.ColumnCount - 1] != 0)
            {
                matrix[i, matrix.ColumnCount - 1] = (float)(r.NextDouble() - 0.5) * 2 * 10;
            }
        }
        return matrix;

    }

    public  void AkFun()
    {

        // When making the matrix vector multiplication the bias of the Vector (1) is lost so i have to add it again

        for (int i = 0; i < valVec.Count; i++)
        {
            valVec[i] = (float)Math.Tanh(valVec[i]);

        }

        actVec = Vector<float>.Build.Dense(valVec.Count + bias, 1);
        for (int i = 0; i < valVec.Count; i++)
        {

            actVec[i] = valVec[i];
        }

       



    }




    public void RunBrain()
    {

        // getting Imputvalues
        actVec = Vector<float>.Build.Random(input.Count + bias);
        for (int i = 0; i < input.Count; i++)
        {
            actVec[i] = input[i]();

        }
        actVec[actVec.Count - 1] = 1;


        // AkFun also builds the new actVec
        valVec = inputNetwork.Multiply(actVec);
        AkFun();

        for (int i = 0; i < network.Count; i++)
        {
            valVec = network[i].Multiply(actVec);
            AkFun();
        }

        valVec = outputNetwork.Multiply(actVec);
        AkFun();

        for (int i = 0; i < valVec.Count; i++)
        {
            if (0 < valVec[i])
            {
                output[i]();
            }


        }



    }



    public void MutateBrain()
    {

        //setting up the diffrent Layers of the Network



        inputNetwork = Mutate(inputNetwork);


        for (int i = 0; i < hiddenLayers; i++)
        {




            network[i] = Mutate(network[i]);




        }
        outputNetwork = Mutate(outputNetwork);







    }

    public Matrix<float> Mutate(Matrix<float> matrix)
    {



        //ndomise links
        for (int i = 0; i < matrix.RowCount; i++)
        {
            for (int j = 0; j < matrix.ColumnCount - bias; j++)
            {
                if (matrix[i, j] != 0)
                {



                    if (r.NextDouble() < 0.0000001)
                    {



                        matrix[i, j] +=(float)(r.NextDouble() * 1 - 0.5);

                        if (matrix[i, j] > 1)
                        {
                            matrix[i, j] = 1;
                        }
                        else if (matrix[i, j] < -1)
                        {
                            matrix[i, j] = -1;
                        }

                    }
                }


            }
        }

        // ndomize the values for the biases
        for (int i = 0; i < matrix.RowCount; i++)
        {

            if (r.NextDouble() < 0.1)
            {




                matrix[i, matrix.ColumnCount - 1] += (float)(r.NextDouble() * 1 - 0.5);

                if (matrix[i, matrix.ColumnCount - 1] > 5)
                {
                    matrix[i, matrix.ColumnCount - 1] = 5;
                }
                else if (matrix[i, matrix.ColumnCount - 1] < -5)
                {
                    matrix[i, matrix.ColumnCount - 1] = -5;
                }

            }
        }
        // switch two values of the links
        if (r.NextDouble() < 0.000001)
        {

            int aR = r.Next(matrix.RowCount);
            int aC = r.Next(matrix.ColumnCount);
            int bR = r.Next(matrix.RowCount);
            int bC = r.Next(matrix.ColumnCount);
            float val = matrix[aR, aC];

            matrix[aR, aC] = matrix[bR, bC];
            matrix[bR, bC] = val;




        }




        return matrix;
    }

}


