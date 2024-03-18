using System.Drawing.Drawing2D;


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

                            if((x-i)%10<2){
                            Map[i,j+2] = block;
                             }
                

            }


        }

    }



}



struct Window
{

    public static int x = Control.size;
    public static int y = Control.size;
}
class MainProgram : Form
{





    int frames = 0;
    public static float time = 0;

    public MainProgram()
    {






        DoubleBuffered = true;

        // Set up the form
        Size = new Size(Window.x + 16, Window.y + 38);
        Text = "C# Animation Example";
        Grid.space = (float)this.ClientSize.Width / ((float)Grid.x);

        // Create a timer to update the animation
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 16; // Update every 16 milliseconds (approximately 60 frames per second)
        timer.Tick += Timer_Tick;
        time += timer.Interval / 1;
        timer.Start();



    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        frames += 1;
        if (frames > 60)
        {
            Close();
        }

        Invalidate();

    }

    protected override void OnPaint(PaintEventArgs e)
    {







        // Draw the animated element (a rectangle in this case)


        for (int i = 0; i < Control.pop; i++)
        {

            Creature inc = Control.data[i];

            Color myColor = Color.FromArgb((int)((inc.inputNetwork.FrobeniusNorm() * 25) % 255),
            (int)((inc.network[0].FrobeniusNorm() * 25) % 255),
             (int)((inc.outputNetwork.FrobeniusNorm() * 25) % 255));

            e.Graphics.FillRectangle(

           new SolidBrush(myColor),
           new Rectangle((int)(inc.x * Grid.space),
               (int)(inc.y * Grid.space),
               (int)(Grid.space),
               (int)(Grid.space)
           )
       );


        }

        for (int i = 0; i < Grid.x; i++)
        {
            for (int j = 0; j < Grid.y; j++)
            {
                if (Grid.Map[i, j] == 1)
                {
                    e.Graphics.FillRectangle(
                        Brushes.Black,
                        new Rectangle(
                            (int)(i * Grid.space),
                            (int)(j * Grid.space),
                            (int)Grid.space,
                            (int)Grid.space
                        )
                    );
                }
            }
        }


    }




}








class AnimatGen : Form
{





    int frames = 0;
    public static float time = 0;

    int aniGen;
    List<Creature> aniData;
    public AnimatGen(int aniGen)
    {

        this.aniGen = aniGen;




        DoubleBuffered = true;

        // Set up the form
        Size = new Size(Window.x + 16, Window.y + 38);
        Text = "C# Animation Example";
        Grid.space = (float)this.ClientSize.Width / ((float)Grid.x);
        aniData = Control.PullData(aniGen);
        // Create a timer to update the animation
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 16; // Update every 16 milliseconds (approximately 60 frames per second)
        timer.Tick += Timer_Tick;
        time += timer.Interval / 1;
        timer.Start();





    }

    private void Timer_Tick(object? sender, EventArgs e)
    {

        if (frames < Control.generationLength)
        {
            // invalidate increases the score for frames 
            Invalidate();


        }
        else
        {


            Close();




        }




    }

    protected override void OnPaint(PaintEventArgs e)
    {

        aniData = Control.PullPositions(aniGen, frames, aniData);






        for (int i = 0; i < Control.pop; i++)
        {

            Creature inc =aniData[i];

            Color myColor = Color.FromArgb((int)((inc.inputNetwork.FrobeniusNorm() * 25) % 255),
            (int)((inc.network[0].FrobeniusNorm() * 25) % 255),
             (int)((inc.outputNetwork.FrobeniusNorm() * 25) % 255));

            e.Graphics.FillRectangle(

           new SolidBrush(myColor),
           new Rectangle((int)(inc.x * Grid.space),
               (int)(inc.y * Grid.space),
               (int)(Grid.space),
               (int)(Grid.space)
           )
       );


        }


        for (int i = 0; i < Grid.x; i++)
        {
            for (int j = 0; j < Grid.y; j++)
            {
                if (Grid.Map[i, j] == 1)
                {
                    e.Graphics.FillRectangle(
                        Brushes.Black,
                        new Rectangle(
                            (int)(i * Grid.space),
                            (int)(j * Grid.space),
                            (int)Grid.space,
                            (int)Grid.space
                        )
                    );
                }
            }
        }

        frames += 1;

    }





}

