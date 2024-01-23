using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;



partial  class    MainProgram: Form
{

    int GridSize = 5; //px

    int GridX = 500;
    int GridY = 100;
    int WindowSizeX;
    int WindowSizeY;

    int GridSpace;
    Random r = new Random();
    int Pop = 1000;
    int[,] Pos;

    int[,] Map;


    private int xPosition = 0;
    private int xSpeed = 5;

    public void Animation()
    {

        DoubleBuffered = true;

        WindowSizeX = GridX * GridSize;
        WindowSizeY = GridY * GridSize;
        GridSpace = WindowSizeX / GridX;

        Pos = new int[Pop, 2];

        for (int i = 0; i < Pop; i++)
        {
            Pos[i, 0] = r.Next(0, GridX);  // Random X-coordinate (0 to Grid - 1)
            Pos[i, 1] = r.Next(0, GridY);  // Random Y-coordinate (0 to Grid - 1)

        }
        Map = new int[GridX,GridY];
      for (int i = 0; i < GridX; i++)
        {
              for (int j = 0; j < GridY; j++)
        {
          Map[i,j]=0;
          if(j>GridY/2){
            Map[i,j]=1;
          }
        }
        }

        // Set up the form
        Size = new Size(WindowSizeX, WindowSizeY);
        Text = "C# Animation Example";

        // Create a timer to update the animation
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 16; // Update every 16 milliseconds (approximately 60 frames per second)
        timer.Tick += Timer_Tick;
        timer.Start();
       
    }
    void MakeStep()
    {
        for (int i = 0; i < Pop; i++)
        {
            int x=r.Next(-1, 2);
            int y=r.Next(-1, 2);
            if(!(Pos[i, 0]+x<0||Pos[i, 1]+y<0||Pos[i, 0]+x>=GridX||Pos[i, 1]+y>=GridY))
            {
                 //Console.WriteLine("a");
            if(Map[Pos[i, 0]+x,Pos[i, 1]+y]==0){
            Pos[i, 0] += x;
            Pos[i, 1] += y;
        }}

        }

    }
    private void Timer_Tick(object? sender, EventArgs e)
    {
        // Update the animation state
       
        MakeStep();

        // Force the form to redraw
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the animated element (a rectangle in this case)
        

        for (int i = 0; i < Pop; i++)
        {
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(Pos[i, 0] * GridSpace, Pos[i, 1] * GridSpace, GridSpace, GridSpace));


        }

        for (int i = 0; i < GridX; i++)
        {
              for (int j = 0; j < GridY; j++)
        {
            if(Map[i,j]==1){
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(i * GridSpace, j * GridSpace, GridSpace, GridSpace));
            }
          
        }
        }
    }

    public static void Main()  // <-- Entry point
    {


        Application.Run(new MainProgram());
    }




}
