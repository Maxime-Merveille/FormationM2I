//_______________________________________________________________________________________________________________________________________//
//   Programme développé par                                                                                                             //
//   ___  ___   ___    _   _   _____   ___ ___ _____           ___  ___  _____   _____   _   _   _____   _____   _       _       _____   //
//   |  \/  |  / _ \  | \ / | |_   _| |  \/  | |  ___|         |  \/  | |  ___| | ___ | | | | | |  ___| |_   _| | |     | |     |  ___|  //
//   | .  . | / /_\ \  \ V /    | |   | .  . | | |__           | .  . | | |__   | |_/ / | | | | | |__     | |   | |     | |     | |__    //
//   | |\/| | |  _  |  / _ \    | |   | |\/| | |  __|          | |\/| | |  __|  |    /  | | | | |  __|    | |   | |     | |     |  __|   //
//   | |  | | | | | | / / \ \  _| |_  | |  | | | |___          | |  | | | |___  | |\ \  \ \_/ / | |___   _| |_  | |____ | |____ | |___   //
//   \_|  |_/ \_| |_/ \/   \/ |_____| \_|  |_/ \____/          \_|  |_/ \____/  \_| \_|  \___/  \____/  |_____| \_____/ \_____/ \____/   //
//                                                                                                                                       //
//                                                      /\_/\           ___                                                              //
//                                                     = o_o =_______    \ \                                                             //
//                                                      __^      __(  \___) )                                                            //
//                                                  (@)<_____>__(_____)____/                                                             //
//                                                                                                                                       //
//	 Le 07/01/2026                     mail: maximemerveille59@gmail.com                  github: https://github.com/Maxime-Merveille    //
//_______________________________________________________________________________________________________________________________________//

using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.CompteBancaire
{
    internal static class IHMCompteBancaire
    {
        public static Client client1 { get; set; }
        public static Client client2 { get; set; }

        /// <summary>
        /// Init des clients 
        /// </summary>
        private static void Init()
        {
            client1 = new Client("Maxime", "Merveille", 123456, 0666548778);
            client2 = new Client("Jean", "TrucMachin", 987654, 0696969696);

            ComptePayant cptPayant = new ComptePayant(1234, 10000.00, client1, 0.05f);
            CompteCourant cptCourant = new CompteCourant(2345, 2000.00, client1, 9999);
            CompteEpargne cptEpargne = new CompteEpargne(3456, 2000.00, client2, 0.05f);

            client1.AddCompteBancaire(cptPayant);
            client1.AddCompteBancaire(cptCourant);
            client1.AddCompteBancaire(cptEpargne);

            cptEpargne = new CompteEpargne(9876, 600.00, client2, 0.05f);
            cptCourant = new CompteCourant(8765, 3000.00, client2, 6666);

            client2.AddCompteBancaire(cptEpargne);
            client2.AddCompteBancaire(cptCourant);


            client1.NewDepotParIdCompte(2345, 5000.00);
            client1.NewRetraitParIdCompte(1234, 1000.00);
            client1.NewDepotParIdCompte(3456, 500.00);

            client2.NewDepotParIdCompte(9876, 5000.00);
            client2.NewRetraitParIdCompte(8765, 1000.00);
        }

        /// <summary>
        /// Methode de test pas beau
        /// </summary>
        public static void Test()
        {
            Init();

            Console.WriteLine(client1);
            Console.WriteLine("\n ==================================\n");

            Console.WriteLine(client2);
            Console.WriteLine("\n ==================================\n");

            Console.WriteLine(client1.GetCompteBancaireById(2345));
            Console.WriteLine(client1.GetCompteBancaireById(1234));
            Console.WriteLine("\n ==================================\n");

            Console.WriteLine(client2.GetCompteBancaireById(9876));
            Console.WriteLine(client2.GetCompteBancaireById(8765));

            Console.WriteLine("\n ==================================\n");

            client1.GetCompteBancaireById(1234).PrintAllOperation();
            client2.GetCompteBancaireById(8765).PrintAllOperation();
        }

        /// <summary>
        /// Recupere l'identifiant du compte 
        /// </summary>
        /// <returns>Int de l'identifiant du compte </returns>
        private static int GetId()
        {
            Console.WriteLine("Entrez l'id du compte");
            return Int32.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Recupere le montant de l'operation 
        /// </summary>
        /// <returns>Double du montant </returns>
        private static double GetMontant()
        {
            Console.WriteLine("Entrez le montant de la transaction");
            return double.Parse(Console.ReadLine());
        }

        /// <summary>
        /// IHM avec menu de choix d'action a effectuer sur le compte client
        /// </summary>
        public static void IHM()
        {
            Init();
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n ===== MENU =====\n");
                Console.WriteLine("Que voulez vous faire ?");
                Console.WriteLine("1 - Afficher le solde du compte par Identifiant");
                Console.WriteLine("2 - Afficher les operation du compte par Identifiant");
                Console.WriteLine("3 - Effectuer un depot par Identifiant");
                Console.WriteLine("4 - Effectuer un retrait par Identifiant");
                Console.WriteLine("5 - Afficher la liste des comptes");
                Console.WriteLine("Autre - Quitter");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Votre solde est de : " + client1.GetCompteBancaireById(GetId()).GetSolde() + " euros.");
                        break;

                    case "2":
                        client1.GetCompteBancaireById(GetId()).PrintAllOperation();
                        break;

                    case "3":
                        client1.NewDepotParIdCompte(GetId(), GetMontant());
                        break;

                    case "4":
                        client1.NewRetraitParIdCompte(GetId(), GetMontant());
                        break;

                    case "5":
                        client1.PrintAllCompteBancaire();
                        break;

                    default:
                        continuer = false;
                        break;
                }
            }

        }
    }
}
