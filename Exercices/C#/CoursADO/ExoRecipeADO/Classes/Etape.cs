using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Classes
{
    internal class Etape
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Etape() { }

        public Etape(string des)
        {
            Description = des;
        }

        public Etape(int id, string des) : this(des)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id : {Id} | {Description}";
        }
    }
}
