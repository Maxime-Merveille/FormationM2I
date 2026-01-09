using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    internal class Lieu : Adresse
    {
        public int Capacite { get; set; }

        public Lieu(string rue, string adresse, int capacite): base(rue, adresse) 
        {
            Capacite = capacite; 
        }
    }
}
