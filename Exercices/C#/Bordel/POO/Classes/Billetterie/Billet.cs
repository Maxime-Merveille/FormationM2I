using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    public enum TypePlace
    {
        Standard,
        Gold, 
        VIP
    }
    internal class Billet
    {
        public int NumeroPlace { get; set;  }
        public Client client { get;  set; }
        public Evenement evenement { get; set; }
        public TypePlace typePlace { get; set; }

        public Billet(int numPlace, Client cli, Evenement even, TypePlace tPlace)
        {
            NumeroPlace= numPlace;
            client= cli;
            evenement= even;
            typePlace= tPlace;
        }

    }
}
