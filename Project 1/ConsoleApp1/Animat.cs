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

        for (int i = 0; i < x - 0; i++)
        {
            for (int j = 0; j < y - 0; j++)
            {

                if (j == x / 2|| i ==y/2)
                {
                    Map[i, j] = block;
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
        timer.Interval = 1; // Update every 16 milliseconds (approximately 60 frames per second)
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

            Creatur inc = Control.data[i];

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

    int aniGen ;

    public AnimatGen(int aniGen)
    {
            
        this.aniGen = aniGen;




        DoubleBuffered = true;

        // Set up the form
        Size = new Size(Window.x + 16, Window.y + 38);
        Text = "C# Animation Example";
        Grid.space = (float)this.ClientSize.Width / ((float)Grid.x);

        // Create a timer to update the animation
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 100; // Update every 16 milliseconds (approximately 60 frames per second)
        timer.Tick += Timer_Tick;
        time += timer.Interval / 1;
        timer.Start();

        



    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        // i invalidata this here because otherwise it makes 2 steps to mutch
        if (!(frames > Control.generationLength))
        {
            Console.WriteLine(frames);
            Invalidate();
        }else{

        
        Close();
        
        
        
        
        }
frames += 1;


        
    }

    protected override void OnPaint(PaintEventArgs e)
    {

        List<Creatur> aniData = Control.GetDataFromFile(aniGen,frames);






        // Draw the animated element (a rectangle in this case)


        for (int i = 0; i < Control.pop; i++)
        {

            Creatur inc = aniData[i];

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

