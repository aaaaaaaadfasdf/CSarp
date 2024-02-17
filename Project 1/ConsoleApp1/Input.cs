using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

public partial struct Creatur
{
    public  List<Func<float>> input = [];

    public void InputCons()
    {
        input = new List<Func<float>>
        {
            ImpDirectionN,
            ImpDirectionO,
            ImpDirectionS,
            ImpDirectionW,
            ImpTime
        };
    }

    public float ImpDirectionN()
    {
        int c = 0;
        int y = 0;
        while (true)
        {
            c += 1;
            if (x + c >= Grid.x)
            {
                return c;
            }
            if (!(Grid.Map[x + c, y] == 0))
            {
                return (float)1 / c;
            }
        }
    }

    public float ImpDirectionO()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (y + c >= Grid.y)
            {
                return 1 / c;
            }
            if (!(Grid.Map[x, y + c] == 0))
            {
                return (float)1 / c;
            }
        }
    }

    public float ImpDirectionS()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (x - c < 0)
            {
                return 1 / c;
            }
            if (!(Grid.Map[x - c, y] == 0))
            {
                return (float)1 / c;
            }
        }
    }

    public float ImpDirectionW()
    {
        int c = 0;

        while (true)
        {
            c += 1;
            if (y - c < 0)
            {
                return 1 / c;
            }
            if (!(Grid.Map[x, y - c] == 0))
            {
                return (float)1 / c;
            }
        }
    }

    public  float ImpTime()
    {
        return (float)1 / (MainProgram.time + 1);
    }
}
