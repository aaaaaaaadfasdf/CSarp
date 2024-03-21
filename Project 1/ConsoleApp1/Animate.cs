using System.Drawing.Drawing2D;




struct Window
{

    public static int x = Control.sizex;
    public static int y = Control.sizey;
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

