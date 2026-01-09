using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    internal class Client
    {
        // Attrbiut client
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Adresse adresse { get; set; }
        public int Age { get; set; }
        public string NumeroTelephone { get; set; }
        public List<Billet> ListeBillet { get; set; }

        public Client(string nom, string prenom, Adresse ad, int age, string numTel)
        {
            Nom = nom;
            Prenom = prenom;
            adresse = ad;
            Age = age;
            NumeroTelephone = numTel;
            ListeBillet = new List<Billet>();
        }
    }
}
