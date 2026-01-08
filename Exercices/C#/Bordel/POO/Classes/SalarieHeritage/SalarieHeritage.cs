//_______________________________________________________________________________________________________________________________________//
//   Programme développé par                                                                                                             //
//   ___  ___   ___    _   _   _____   ___ ___ _____          ___  ___  _____   _____   _   _   _____   _____   _       _       _____    //
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
//	 Le 08/01/2026                     mail: maximemerveille59@gmail.com                  github: https://github.com/Maxime-Merveille    //
//_______________________________________________________________________________________________________________________________________//

using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.SalarieHeritage
{
    /// <summary>
    /// Classe gerant les salariée
    /// </summary>
    internal class SalarieHeritage
    {
        private static int _totalSalarie { get; set; } = 0;
        private static double _totalSalaire { get; set; } = 0;

        public int? Matricule { get; set; }
        public string? Service { get; set; }
        public string? Categorie { get; set; }
        public string? Nom { get; set; }
        public double? Salaire { get; set; }


        protected SalarieHeritage()
        {
            _totalSalarie++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matricule">Matricule en format Int32</param>
        /// <param name="service">Service sous format String</param>
        /// <param name="categorie">Categorie sous format String</param>
        /// <param name="nom">Nom sous format String</param>
        /// <param name="salaire">Salaire sous format Double</param>
        public SalarieHeritage(int matricule, string service, string categorie, string nom, double salaire) : this()
        {
            Matricule = matricule;
            Service = service;
            Categorie = categorie;
            Nom = nom;
            Salaire = salaire;

            _totalSalaire += salaire;
        }
        /// <summary>
        /// Permet d'afficher le salaire de l'instance 
        /// </summary>
        public virtual void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {Nom}, Matricule : {Matricule} est de {Salaire} euros");
        }

        /// <summary>
        /// Permet d'afficher le nombre total d'instance de la classe Salarie
        /// </summary>
        public static void AfficherTotalSalarie()
        {
            Console.WriteLine($"Il y a {_totalSalarie} salarie dans l'entreprise");
        }

        /// <summary>
        /// Permet d'afficher le nombre total d'instance de la classe Salarie et leur salaire combiné
        /// </summary>
        public static void AfficherTotalSalaire()
        {
            Console.WriteLine($"Le salaire total pour les {_totalSalarie} salaries est de {_totalSalaire} euros");
        }

        /// <summary>
        /// Reset le compteur d'instance de Salarie a zero
        /// </summary>
        public static void ResetNombreSalarie()
        {
            _totalSalarie = 0;
        }

        public override string ToString()
        {
            return $"Le "+ this.GetType().Name +$" {Nom} de Matricule {Matricule},\n Service {Service},\n Categorie {Categorie},\n Salaire {Salaire}";
        }
    }
}
