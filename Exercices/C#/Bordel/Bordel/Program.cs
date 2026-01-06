//_______________________________________________________________________________________________________________________________________//
//   Programme développé par                                                                                                             //
//   ___  ___   ___    _   _   _____   ___ ___ _____           ___  ___  _____   _____   _   _   _____   _____   _       _       _____   //
//   |  \/  |  / _ \  | \ / | |_   _| |  \/  | |  ___|         |  \/  | |  ___| | ___ | | | | | |  ___| |_   _| | |     | |     |  ___|  //
//   | .  . | / /_\ \  \ V /    | |   | .  . | | |__           | .  . | | |__   | |_/ / | | | | | |__     | |   | |     | |     | |__    //
//   | |\/| | |  _  |  / _ \    | |   | |\/| | |  __|          | |\/| | |  __|  |    /  | | | | |  __|    | |   | |     | |     |  __|   //
//   | |  | | | | | | / / \ \  _| |_  | |  | | | |___          | |  | | | |___  | |\ \  \ \_/ / | |___   _| |_  | |____ | |____ | |___   //
//   \_|  |_/ \_| |_/ \/   \/ |_____| \_|  |_/ \____/          \_|  |_/ \____/  \_| \_|  \___/  \____/  |_____| \_____/ \_____/ \____/   //
//                                                                                                                                       //
//                                               /\_/\           ___                                                                     //
//                                              = o_o =_______    \ \                                                                    //
//                                               __^      __(  \___) )                                                                   //
//                                           (@)<_____>__(_____)____/                                                                    //
//	 Le 06/01/2026                                                                                                                       //
//_______________________________________________________________________________________________________________________________________//
using System;

namespace Bordel
{
    internal class Program
    {

        public static void Exercice1()
        {
            const int AGE_MIN = 18;

            Console.WriteLine("Entrez votre nom");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez votre prenom");
            string prenom = Console.ReadLine();

            Console.WriteLine($"Bonjour, {nom} {prenom}!");

            Console.WriteLine("Entrez votre age");
            int age = Int32.Parse(Console.ReadLine());

            if (age < AGE_MIN)
            {
                // Mineur⛏️
                Console.WriteLine("Vous etes trop jeune !");
            }
            else
            {
                Console.WriteLine("Entrez!");

                int ardoise = 0;
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Choisissez entre :\n1 - Coca\n2 - Biere\n3 - Eau");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Ce sera 5 euro");
                            ardoise += 5;
                            break;
                        case "2":
                            Console.WriteLine("C'est 7 euro la pinte");
                            ardoise += 7;
                            break;
                        case "3":
                            Console.WriteLine("C'est 2 euro");
                            ardoise += 2;
                            break;
                        case "STOP":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Erreur, 10 euros d'ammende");
                            ardoise += 10;
                            break;
                    }
                }
                Console.WriteLine($"Tu me dois {ardoise} euros");
            }


        }

        public static void Exercice2()
        {
            Random rnd = new Random();
            int numCache = rnd.Next(1, 101);

            Console.WriteLine("Jeu du nombre mystere, choisissez un niveau de difficulté :\n1 - Facile\n2 - Moyen\n3 - Difficile\n4 - Dark Souls");

            //TODO mieux gerer les erreurs saisie
            int nombreVie = Console.ReadLine() switch
            {
                "1" => 20,
                "2" => 10,
                "3" => 5,
                "4" => 1,
                _ => 0
            };

            Console.WriteLine($"Debut du jeu !\nLe nombre mystere est compris entre 1 et 100, Vous avez {nombreVie} vies pour le trouver !");

            while (nombreVie != 0)
            {
                Console.WriteLine("Entrez un nombre");

                int guess = Convert.ToInt32(Console.ReadLine());

                //TODO trop de if, raccourcir en switch ?

                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine($"Apprend a compter, -1 vie, il t'en reste {--nombreVie}.");
                }
                else if (guess == numCache)
                {
                    Console.WriteLine($"Gagné! Il vous restait {nombreVie} vies");
                    break;
                }
                else if (guess < numCache)
                {
                    Console.WriteLine($"Raté, le nombre mystere est plus GRAND, il vous reste {--nombreVie} vies.");
                }
                else if (guess > numCache)
                {
                    Console.WriteLine($"Raté, le nombre mystere est plus PETIT, il vous reste {--nombreVie} vies.");
                }
                else
                {
                    Console.WriteLine("Erreur de saisie");
                }
            }

            if (nombreVie == 0)
            {
                Console.WriteLine($"Perdu ! Le nombre etait {numCache}.");
            }
        }

        public static void Exercice3()
        {
            // Definition des variables 
            Random rnd = new Random();
            char[] choix = { 'R', 'V', 'B', 'J' };
            string pions = "";
            string reponse = "";
            string resultat = "";
            int essai = 0;

            // Text debut du jeu
            Console.WriteLine("Jeu MASTERMIND ");
            Console.WriteLine("Trouvez les bonnes couleurs au bons emplacements pour gagner, vous avez 10 essais, les régles sont :\nX - Couleur non-existante\n* - Couleur existante mais au mauvais emplacement\nO - Bonne couleur au bon emplacement.");
            Console.WriteLine("\nLes couleurs disponibles sont :\nR - Rouge\nV - Vert\nB - Bleu\nJ - Jaune");

            // Gerer la difficulté
            Console.WriteLine("\nChoisissez un niveau de difficultée :\n1 - Facile\n2 - Moyen\n3 - Difficile\n4 - Cherche toi un hobby");
            int nombrePions = Console.ReadLine() switch
            {
                "1" => 4,
                "2" => 6,
                "3" => 8,
                "4" => 10,
                _ => 0

            };

            // Generation des pions cachés
            for (int i = 0; i < nombrePions; i++)
            {
                pions += choix[rnd.Next(0, 4)];
            }

            // Boucle de jeu principale, 10 essais 
            while (essai <= 10 && nombrePions > 0)
            {
                Console.WriteLine("Entrez votre reponse :");

                reponse = Console.ReadLine();
                resultat = ""; // reset de resultat pour reecriture de celui ci pour ce tour
                essai++;

                // Erreur si la reponse est pas de la bonne taille ou ne contient pas les bons caracteres
                if (reponse.Length != nombrePions || !reponse.ContainsAny(choix))
                {
                    Console.WriteLine("Erreur de saisie");
                }
                else
                {
                    // Generation du resultat
                    for (int i = 0; i < nombrePions; i++)
                    {
                        if (reponse[i] == pions[i])
                        {
                            resultat += "O";
                        }
                        else if (pions.Contains(reponse[i]))
                        {
                            resultat += "*";
                        }
                        else
                        {
                            resultat += "X";
                        }
                    }
                    Console.WriteLine($"Resultat :\n{resultat}");

                    //Si le resultat ne contient que des 'O', alors on gagne
                    if (!resultat.Contains('*') && !resultat.Contains('X'))
                    {
                        Console.WriteLine("Vous avez gagné");
                        break;
                    }

                }
            }
            // TODO gerer les mauvaises saisie de difficulté
            Console.WriteLine($"Vous avez trouvez en {essai} essais.");
        }

        static void Main(string[] args)
        {

            //Exercice1();
            //Exercice2();
            Exercice3();
        }
    }
}