using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    internal class Evenement
    {
        public string Nom { get; set; }
        public Lieu lieu { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public int NombrePlace {  get; set; }
        public List<Billet> ListeBillet { get;set;  }

        public Evenement(string nom, Lieu l, DateTime date, string heure, int nbrPlace)
        {
            Nom = nom;
            lieu = l;
            Date = date;
            Heure = heure;
            NombrePlace = nbrPlace;
            ListeBillet = new List<Billet>();   
        }
    }
}
