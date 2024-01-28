using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Data;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Xml;

struct Grid
{
    public static int size = 5;
    public static int x = 500;
    public static int y = 100;
    public static int space = Window.x / x;

    public static int[,] Map;

    public Grid()
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






struct Window
{
    public static int x = Grid.x * Grid.size;
    public static int y = Grid.y * Grid.size;

}




/*
struct Data{

   

    
    public static List<float> data = [];
    public static List<float> position = [];
    public static List<float> creatur = [];

    public static List<float> links = [];

    public static List<float> link = [];




    public static void MakeData(){
Random r = new Random();
for(int i=0;i<CProp.Pop;i++){

 for(int j =0;j<CProp.inputUsed;j++){
        link = [r.Next(0, CProp.inputNum),r.Next(0, 100)/100,r.Next(0, CProp.inputNum)];
        links.AddRange(link);
        link.Clear();
}
position = [r.Next(0, Grid.x),r.Next(0, Grid.y)];

creatur.AddRange(position);
position.Clear();

creatur.AddRange(links);
links.Clear();

data.AddRange(creatur);
creatur.Clear();

}
       


    }
}
*/



partial class MainProgram : Form
{

    static readonly Random r = new();
    Grid grid = new(); // so that the constructor runs and Map is made
    public static Imput imput = new(); // so that the constructor runs
    public static Output  output = new(); // so that the constructor runs








    public MainProgram()
    {
        // Setup Creaturs
        for (int i = 0; i < CreProp.Pop; i++)
        {
            CreProp.data.Add(new Creatur());
        }

       Console.Write( CreProp.data[0].links);
       Console.Write( Grid.Map);
        // Map



        DoubleBuffered = true;







        // Set up the form
        Size = new Size(Window.x, Window.y);
        Text = "C# Animation Example";

        // Create a timer to update the animation
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 16; // Update every 16 milliseconds (approximately 60 frames per second)
        timer.Tick += Timer_Tick;
        timer.Start();



    }
    void MakeStep()
    {
        for (int i = 0; i < CreProp.Pop; i++)
        {
            Creatur inc = CreProp.data[i];
            int x = r.Next(-1, 2);
            int y = r.Next(-1, 2);
            if (!(inc.x + x < 0 || inc.y + y < 0 || inc.x + x >= Grid.x || inc.y + y >= Grid.y))
            {

                if (Grid.Map[inc.x + x, inc.y + y] == 0)
                {
                    inc.x += x;
                    inc.y += y;
                    CreProp.data[i] = inc;
                }
            }

        }

    }



    private void Timer_Tick(object? sender, EventArgs e)
    {
        // Update the animation state

      for (int i = 0; i < CreProp.Pop; i++)
        {
            CreProp.data[i].RunBrain();
        }

        // Force the form to redraw
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the animated element (a rectangle in this case)


        for (int i = 0; i < CreProp.Pop; i++)
        {
            Creatur inc = CreProp.data[i];
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(inc.x * Grid.space, inc.y * Grid.space, Grid.space, Grid.space));


        }

        for (int i = 0; i < Grid.x; i++)
        {
            for (int j = 0; j < Grid.y; j++)
            {
                if (Grid.Map[i, j] == 1)
                {
                    e.Graphics.FillRectangle(Brushes.Black, new Rectangle(i * Grid.space, j * Grid.space, Grid.space, Grid.space));
                }

            }
        }
    }

    public static void Main()  // <-- Entry point
    {


        Application.Run(new MainProgram());
    }




}
