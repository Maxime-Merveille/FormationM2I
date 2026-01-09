using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.Billetterie
{
    internal class GestionBilleterie
    {
        public static Client client { get; set;  }
        public static List<Evenement> ListeEvent { get; set; }


        public static void Init()
        {
            client = new Client("Merveille", "Maxime", new Adresse("Rue de la Paix", "Paris"), 24, "0659371964");

            ListeEvent = new List<Evenement>();
            ListeEvent.Add(new Evenement("Zenith", new Lieu("Je sais pas ", "Lille", 50000), DateTime.Today, )); 
        }
    }
}
