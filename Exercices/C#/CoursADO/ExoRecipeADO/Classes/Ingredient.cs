using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Classes
{
    internal class Ingredient
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Ingredient() { }

        public Ingredient(string nom)
        {
            Nom = nom;
        }

        public Ingredient(int id, string nom) : this(nom)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id : {Id} | {Nom}";
        }
    }
}
