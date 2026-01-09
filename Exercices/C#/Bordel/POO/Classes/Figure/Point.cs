using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Figure
{
    internal class Point
    {
        double PosX { get; set; }

        double PosY { get; set; }

        public Point(double posX, double posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public override string ToString()
        {
            return $"X:{PosX}, Y{PosY}";
        }
    }
}
