using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    internal class Adresse
    {
        public string Rue { get; set; }
        public string Ville { get; set; }  
        
        public Adresse(string rue, string ville) {
            Rue = rue;
            Ville = ville;
        }

        public override string ToString()
        {
            return $"Rue {Rue}, {Ville}";
        }
    }
}
