
using MathNet.Numerics.LinearAlgebra;




public partial class Creature
{

    static Random r = new();
    public int x = 100;
    public int y = 100;



    // Muatation variables
    // the Mutation is alway countet in how many mutation per nural network 
    // all the Change variable declare how big the change is in + and - 
    public const float mutationChance = 10f;
    public const float mutationChange = .01f;
    public const float mutationRandom = .01f;


    public const float mutationBiasChance = 10f;
    public const float mutationBiasChange = .01f;
    const float mutationRandomBias = .01f;

    public const float mutationSwitchChance = .5f;

    public const float ChanceToDeepMutate = .2f;
    public const float DeepMutateChange = .1f;

public const float totoalLinks =0.5f; // how many percent of the connenction are non 0

    public Matrix<float> inputNetwork;

    public List<Matrix<float>> network = [];

    public Matrix<float> outputNetwork;

    public Vector<float> actVec;
    public Vector<float> valVec;


    // consts


    public const int bias = 1;


    public const int neuronsPerLayer = 4;
    public const int hiddenLayers =  4; // this is alway plus one because it is really the links


    public int toalNetValCount; // how many Values are there in all parts of the network

    public List<float> remember = Enumerable.Repeat(0f, 6).ToList();
    public int rememberCounter = 0;


    public Creature()
    {


        x = r.Next(0, Grid.x);
        y = r.Next(0, Grid.y);








        InputCons();    //the constructor 
        OutputCons();   //the constructor


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




        toalNetValCount = neuronsPerLayer*(hiddenLayers+input.Count+output.Count);
    }


    public Matrix<float> MakeMatrix(Matrix<float> matrix)
    {






        // This function creates a Matrix wher exactly 50% (50% is determened by the totoalLinks variable) of all the values
        // are 0 and the other 50% are between 1 and -1 
        List<float> list = [];
        for (int i = 0; i < matrix.RowCount * matrix.ColumnCount; i++)
        {
            //here you can Change how many are = and how many are one
            if (i < matrix.RowCount * matrix.ColumnCount * totoalLinks)
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
        for (int i = 0; i < matrix.RowCount; i++)
        {
            if (matrix[i, matrix.ColumnCount - 1] != 0)
            {
                matrix[i, matrix.ColumnCount - 1] = (float)(r.NextDouble() - 0.5) * 2 * 10;
            }
        }
        return matrix;

    }

    public void AkFun()
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


        // AkFun also builds the new actVec because the bias is lost
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
            // this updates the rememberCounter so the RememberOut knows which element of the array it should update
            if (output[i] == RememberOutPos)
            {
                rememberCounter += 1;
            }


            if (0 < valVec[i])
            {
                output[i](i);
            }





        }



    }



    public void MutateBrain()
    {

        //setting up the diffrent Layers of the Network



        inputNetwork = MutateMatrix(inputNetwork);


        for (int i = 0; i < hiddenLayers; i++)
        {
            network[i] = MutateMatrix(network[i]);
        }
        outputNetwork = MutateMatrix(outputNetwork);





    }

    public Matrix<float> MutateMatrix(Matrix<float> matrix)
    {
        float mutationChancePerVal =mutationChance/toalNetValCount;
        float mutationRandomPerVAl =mutationRandom/toalNetValCount;
        //ndomise links
        for (int i = 0; i < matrix.RowCount; i++)
        {
            for (int j = 0; j < matrix.ColumnCount - bias; j++)
            {
                if (matrix[i, j] != 0)
                {



                    if (r.NextDouble() < mutationChancePerVal)
                    {


                        // change a random Value
                        matrix[i, j] += (float)(r.NextDouble() * mutationChange * 2 - mutationChange);

                        if (matrix[i, j] > 1)
                        {
                            matrix[i, j] = 1;//(float)r.NextDouble() * 2 - 1;
                        }
                        else if (matrix[i, j] < -1)
                        {
                            matrix[i, j] = -1;//(float)r.NextDouble() * 2 - 1;
                        }

                    }
                    // jump to a random alue
                    if (r.NextDouble() < mutationRandomPerVAl)
                    {




                        matrix[i, j] = (float)r.NextDouble() * 2 - 1;


                    }




                }


            }
        }


float mutationBiasChancePerVal =mutationBiasChance/toalNetValCount;
float mutationRandomBiasPerVal =mutationRandomBias/toalNetValCount;
        // ndomize the values for the biases
        for (int i = 0; i < matrix.RowCount; i++)
        {

            if (r.NextDouble() < mutationBiasChancePerVal)
            {

                if(matrix[i, matrix.ColumnCount - 1]!=0){



                // change value +- a ceratain value
                matrix[i, matrix.ColumnCount - 1] += (float)(r.NextDouble() * 2 * mutationBiasChange - mutationBiasChange);

                if (matrix[i, matrix.ColumnCount - 1] > 5)
                {
                    matrix[i, matrix.ColumnCount - 1] = 5;//(float)r.NextDouble() * 10 - 5;
                }
                else if (matrix[i, matrix.ColumnCount - 1] < -5)
                {
                    matrix[i, matrix.ColumnCount - 1] = -5;// (float)r.NextDouble() * 10 - 5;
                }

            }


            // change value to a certain value
            if (r.NextDouble() < mutationRandomBiasPerVal)
            {


                matrix[i, matrix.ColumnCount - 1] = (float)r.NextDouble() * 10 - 5;

            }

}

        }
        // switch two values of the links
        if (r.NextDouble() < mutationSwitchChance)
        {

            int aR = r.Next(matrix.RowCount);
            int aC = r.Next(matrix.ColumnCount);
            int bR = r.Next(matrix.RowCount);
            int bC = r.Next(matrix.ColumnCount);
            float val = matrix[aR, aC];

            matrix[aR, aC] = matrix[bR, bC];
            matrix[bR, bC] = val;




        }


        if (r.NextDouble() < ChanceToDeepMutate)
        {
            //ndomise links
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount - bias; j++)
                {

                    if (matrix[i, j] != 0)
                    {
                        matrix[i, j] += (float)(r.NextDouble() * DeepMutateChange * 2 - DeepMutateChange);

                        if (matrix[i, j] > 1)
                        {
                            matrix[i, j] = (float)r.NextDouble() * 2 - 1;
                        }
                        else if (matrix[i, j] < -1)
                        {
                            matrix[i, j] = (float)r.NextDouble() * 2 - 1;
                        }


                    }
                }
            }

            for (int i = 0; i < matrix.RowCount; i++)
            {


                if (matrix[i, matrix.ColumnCount - 1] != 0)
                {

                    



                    matrix[i, matrix.ColumnCount - 1] += (float)(r.NextDouble() * DeepMutateChange * 2 - DeepMutateChange);

                    if (matrix[i, matrix.ColumnCount - 1] > 5)
                    {
                        matrix[i, matrix.ColumnCount - 1] = (float)r.NextDouble() * 10 - 5;
                    }
                    else if (matrix[i, matrix.ColumnCount - 1] < -5)
                    {
                        matrix[i, matrix.ColumnCount - 1] = (float)r.NextDouble() * 10 - 5;
                    }

                }
            }
       
       
        }
        return matrix;
    }

}


