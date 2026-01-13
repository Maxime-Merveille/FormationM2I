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
            ListeEvent.Add(new Evenement("Zenith", new Lieu("Je sais pas ", "Lille", 30000), DateTime.Today, "5h08", 20000));
            ListeEvent.Add(new Evenement("Stade de france", new Lieu("Saint denis ", "Paris", 50000), DateTime.Today, "20h00", 45000));

            client.ListeBillet.Add(new Billet(2525, client, ListeEvent[0],TypePlace.Standard));
            client.ListeBillet.Add(new Billet(6767, client, ListeEvent[1],TypePlace.Gold));
        }

        public static void Lauch()
        {
            Console.WriteLine("\n====== Info du client ======\n");
            Console.WriteLine($"\nClient {client.Nom} {client.Prenom}\nAdresse : {client.adresse}\nNombre de billet dans le panier :{client.ListeBillet.Count}");

            Console.WriteLine("\n====== Info des evenement  ======\n");
            foreach (Evenement eve in ListeEvent)
            {
                Console.WriteLine($"\nEvenement au {eve.Nom}\n{eve.NombrePlace} places\n{eve.lieu}");
            }
            Console.WriteLine("\n====== Info des billet du client  ======\n");
            foreach (Billet bill in client.ListeBillet)
            {
                Console.WriteLine($"\nBillet numero {bill.NumeroPlace}\nEvenement : {bill.evenement.Nom}, {bill.evenement.lieu}\nType de place : {bill.typePlace}");
            }
        }
    }
}
