

static class Grid
{

    public static int x = Control.gridx;
    public static int y = Control.gridy;


// This is super practucul because i dont have to use magic numbers in my code
    public static int block = 1;
    public static int air = 0;
    public static int steptOn = 3;
    public static int food = 4;

    public static int creatur =2;
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

       
    }



}

