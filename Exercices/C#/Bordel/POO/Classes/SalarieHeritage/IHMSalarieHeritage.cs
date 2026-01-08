using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.SalarieHeritage
{
    internal class IHMSalarieHeritage
    {
        public static SalarieHeritage[] _salarieTab = new SalarieHeritage[5];
        public static void GenererEmployee()
        {
            _salarieTab[0] = new SalarieHeritage( 123456, "DRH", "RH", "Jean", 25000.99);
            _salarieTab[1] = new SalarieHeritage( 546512, "DSI", "Developpeur", "Marc", 45000.00);
            _salarieTab[2] = new SalarieHeritage( 646844, "Entretient", "Tech", "Patrick", 27500.00);
            _salarieTab[3] = new Commercial( 8445464, "Bullshit", "JSP", "Marie", 47500.00, 100000.99, 0.05f);
            _salarieTab[4] = new Commercial( 6542248, "Bullshit", "JSPNP", "Thomas", 45000.00, 200000.00, 0.05f);
        }

        public static void LaunchIHM()
        {
            GenererEmployee();
            bool continuer = true;
            int choix = 0;

            while (continuer){
                Console.WriteLine("\n===== Gestion d'employée =====\n");
                Console.WriteLine("Que voulez vous faire ?\n1 - Afficher la liste des employee\n2 - Afficher le salaire d'un employee\n3 - afficher le total des salaire de tous les employee\n4 - Afficher le nombre d'employee\n5 - Recherche par nom\nAutre - quitter le programme.\n");

                switch (Console.ReadLine()) {

                    case "1":

                        foreach(SalarieHeritage employee in _salarieTab)
                        {
                            Console.WriteLine(employee+"\n");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Quel employee voulez vous consulter ?");
                        choix = Int32.Parse(Console.ReadLine());

                        _salarieTab[choix - 1].AfficherSalaire();
                        break;

                    case "3":
                        SalarieHeritage.AfficherTotalSalaire();
                        break;

                    case "4":
                        SalarieHeritage.AfficherTotalSalarie();
                        break;

                    case "5":
                        Console.WriteLine("Quel employee voulez vous rechercher ?");
                        Console.WriteLine(Search(Console.ReadLine()));
                        break;

                    default:
                        continuer = false;
                        break;

                }
            }
        }

        public static SalarieHeritage Search(string nom)
        {
            foreach(SalarieHeritage employee in _salarieTab)
            {
                if (employee.Nom.StartsWith(nom)) 
                    return employee;
            }
            return null;
        }
    }
}
