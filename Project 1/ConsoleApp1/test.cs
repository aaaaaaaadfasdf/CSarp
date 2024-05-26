using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

public class a : Form
{
    int frames = 0;
    public static float time = 0;
    int aniGen;
    List<Creature> aniData;
    private VideoWriter videoWriter;

    public a(int aniGen)
    {
        // Rest of the code remains the same
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        // Rest of the code remains the same
    }

    private void SaveCurrentFrame()
    {
        // Create a Bitmap to capture the current frame
        Bitmap currentFrame = new Bitmap(this.Width, this.Height);
        this.DrawToBitmap(currentFrame, new Rectangle(0, 0, this.Width, this.Height));

        // Convert the Bitmap to a Mat and write it to the VideoWriter
        Mat mat = currentFrame.ToMat();
        videoWriter.Write(mat);

        frames += 1;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Rest of the code remains the same
    }
}