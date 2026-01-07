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

using POO.Classes;

namespace POO
{
    

    internal class Program
    {
        public static void TestChaise()
        {
            // Instanciation des objets de classe Chaise
            Chaise chaise1 = new Chaise(); //Constructeur par default
            Chaise chaise2 = new Chaise(2, "Metal", "Noire"); //Constructeur avec param definis en entrée
            Chaise chaise3 = new Chaise(6, "Plastique", "Bleu");

            //Print des instance de Chaise
            Console.WriteLine(chaise1); // Fait appel a la surchage de la methode .ToString() declarée dans la classe Chaise
            Console.WriteLine(chaise2);
            Console.WriteLine(chaise3.ToString());

            chaise1.NombrePied = 8;
            chaise1.Materiaux = "Uranium";
            chaise1.Couleur = "Transparant";

            Console.WriteLine("\n" + chaise1); // Fait appel a la surchage de la methode .ToString() declarée dans la classe Chaise
        }

        public static void TestSalarie()
        {
            Salarie salarie1 = new Salarie(123456, "Paye", "Comptable", "John Doe", 29000.99);
            Salarie salarie2 = new Salarie(789123, "Informatique", "Developpeur", "Linus Torvald", 45000.99);
            Salarie salarie3 = new Salarie(456789, "Entretient", "Technicien surface", "J'ai plus d'inspi", 24000.99);

            salarie1.AfficherSalaire();
            salarie2.AfficherSalaire();
            salarie3.AfficherSalaire();
            Console.WriteLine("\n");

            Salarie.AfficherTotalSalarie();
            Salarie.AfficherTotalSalaire();

            Console.WriteLine("\nReset du nombre de salarie");
            Salarie.ResetNombreSalarie();

            Salarie.AfficherTotalSalarie();
        }

        public static void TestPendu()
        {
            Console.WriteLine("Jeux du pendu, entrez le nombre d'essai : ");

            Pendu pendu = new Pendu(Int32.Parse(Console.ReadLine()));

            Console.WriteLine($"Mot caché : {pendu.Masque}");

            while (!pendu.TestWin() && pendu.NbEssai > 0)
            {
                Console.WriteLine("Entrer un caractere : ");

                char guess = Console.ReadLine().ToLower().ElementAt(0);

                Console.WriteLine($"le mot cache : {pendu.TestChar(guess)}");
                Console.WriteLine($"Il vous reste {pendu.NbEssai} essais");
            }
            if (pendu.TestWin())
            {
                Console.WriteLine("\n ===== Vous avez gagné ! ===== ");
            }
            else
            {
                Console.WriteLine("\n ===== Vous avez perdu ! =====");
            }
        }

        public static void TestCiterne()
        {
            bool continuer = true;
            string choix = "";
            int quantite = 0;

            Citerne citerne1 = new Citerne(10, 20);
            Citerne citerne2 = new Citerne(10, 15);

            while (continuer)
            {

            
                Console.WriteLine("Que voulez vous faire ?\n1 - Afficher les informations des citernes\n2 - Remplire une citerne\n3 - Vider une citerne\n4 - Voir le stock total des citernes\nAutre pour quitter\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("===== PRINT CITERNE =====\n");
                        Console.WriteLine(" - Citerne 1 - \n" + citerne1 + "\n");
                        Console.WriteLine(" - Citerne 2 - \n" + citerne2 + "\n");
                        break;

                    case "2":
                        Console.WriteLine("Quelle citerne remplire ? (1 ou 2)");
                        choix = Console.ReadLine();

                        Console.WriteLine("Combien de litres voulez vous ajouter ?");
                        quantite = Int32.Parse(Console.ReadLine());

                        if (choix == "1")
                        {
                            Console.WriteLine("\n===== Remplissage citerne 1 =====\n");
                            citerne1.RemplirCiterne(quantite);
                        }
                        else
                        {
                            Console.WriteLine("\n===== Remplissage citerne 2 =====\n");
                            citerne2.RemplirCiterne(quantite);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Quelle citerne vider ? (1 ou 2)");
                        choix = Console.ReadLine();

                        Console.WriteLine("Combien de litres voulez vous retirer ?");
                        quantite = Int32.Parse(Console.ReadLine());

                        if (choix == "1")
                        {
                            Console.WriteLine("\n===== Vidage citerne 1 =====\n");
                            citerne1.ViderCiterne(quantite);
                        }
                        else
                        {
                            Console.WriteLine("\n===== Vidage citerne 2 =====\n");
                            citerne2.ViderCiterne(quantite);
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n ===== Recuperation total de stock des citernes =====\n");
                        Citerne.GetCapaciteTotale();
                        break;

                    default:
                        continuer = false;
                        break;
                }
            }

        }

        static void Main(string[] args)
        {

            //TestChaise();

            //TestSalarie();

            //TestPendu();

            TestCiterne();
           
        }
    }
}
