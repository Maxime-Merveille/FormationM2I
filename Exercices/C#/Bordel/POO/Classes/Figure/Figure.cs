using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Figure
{
    internal abstract class Figure : IDeplacable
    {
        public Point Origine { get; set; }

        public Figure(Point origine)
        {
            Origine = origine;
        }

        public virtual void Deplacement(double posX, double posY)
        {
            Origine = new Point(posX, posY);
        }
    }
}
