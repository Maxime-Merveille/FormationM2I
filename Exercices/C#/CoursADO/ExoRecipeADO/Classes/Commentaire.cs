using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Classes
{
    internal class Commentaire
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Commentaire() { }

        public Commentaire(string des)
        {
            Description = des;
        }

        public Commentaire(int id, string des) : this(des)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id : {Id} | {Description}";
        }
    }
}
