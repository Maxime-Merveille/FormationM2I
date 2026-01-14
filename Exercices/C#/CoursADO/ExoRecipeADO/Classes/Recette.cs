using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Classes
{
    internal class Recette
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int TempsPrep { get; set; }
        public int TempsCuisson { get; set; }
        public string Difficulte { get; set; }
        public int IdCategorie { get; set; }

        public Recette() { }

        public Recette(string nom, int tempsPrep, int tempsCuisson, string difficulte, int idCat)
        {
            Nom = nom;
            TempsPrep = tempsPrep;
            TempsCuisson = tempsCuisson;
            Difficulte = difficulte;
            IdCategorie = idCat;
        }

        public Recette(int id, string nom, int tempsPrep, int tempsCuisson, string difficulte, int idCat) : this(nom, tempsPrep, tempsCuisson , difficulte, idCat)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id : {Id} | {Nom} | {TempsPrep}| {TempsCuisson}| {Difficulte}| {IdCategorie}";
        }

    }
}
