

static class Grid
{

    public static int x = Control.gridx;
    public static int y = Control.gridy;

    public static int block = 1;

    public static int air = 0;
    public static float space;

    public static int[,] Map;

    public static void MakeGrid()
    {
        Map = new int[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {

                Map[i, j] = 0;




            }
        }

        // Set up where the lines are

        for (int i = 10; i < x - 10; i++)
        {
            for (int j = 10; j < y - 10; j++)
            {





            }
        }



        for (int i = 0; i < x - 0; i += 20)
        {
            for (int j = 0; j < y - 0; j++)
            {

                
                            if(j%30<27){
                            Map[i,j] = block;
                             }

                            if((x-j)%30<27){
                            Map[i+10,j] = block;
                             }

                
            }


        }


        for (int i = 0; i < x - 0; i++)
        {
            for (int j = 0; j < y - 0; j += 10)
            {

                
                            if(i%10<6){
                            Map[i,j] = block;
                             }

                            if((x-i)%10<(1+(float)i/100)){
                            Map[i,j+2] = block;
                             }
                

            }


        }

    }



}

