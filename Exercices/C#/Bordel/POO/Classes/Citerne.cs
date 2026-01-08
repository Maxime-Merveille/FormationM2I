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

namespace POO.Classes
{
    internal class Citerne
    {
        // Attribut statiques
        public static int _totalVolumesCiterne { get; set; }

        // Attribut d'instance
        public int PoidsAVide { get; set; }
        public int CapactiteTotale { get; set; }
        public int NiveauRemplissage { get; set; }


        // Constructeurs
        private Citerne() 
        {
            NiveauRemplissage = 0;
        }
        public Citerne(int poidsAVide, int capaciteTotale) : this()
        {
            PoidsAVide = poidsAVide;
            CapactiteTotale = capaciteTotale;
        }

        /// <summary>
        /// Renvoie le poids total de la citerne 
        /// </summary>
        /// <returns>Int correspondant au total du poids de la citerne</returns>
        public int GetPoidsTotal()
        {
            return PoidsAVide + NiveauRemplissage; 
        }

        /// <summary>
        /// Rajoute un nombre donné de litres dans la citerne, 
        /// Print dans la console le resultat de l'operation
        /// </summary>
        /// <param name="litresAjoute">Int correspondant au nombre de litres a rajouter</param>
        public void RemplirCiterne(int litresAjoute)
        {
            _totalVolumesCiterne -= NiveauRemplissage;

            int exces = (NiveauRemplissage + litresAjoute) - CapactiteTotale;

            if (exces > 0)
            {
                
                NiveauRemplissage = CapactiteTotale ;
                Console.WriteLine($"Quantité d'eau dans la citerne apres l'ajout de {litresAjoute} litres: {NiveauRemplissage}/{CapactiteTotale}\n");
                Console.WriteLine($"Exces d'eau recupere : {exces}\n");
            }
            else
            {
                NiveauRemplissage += litresAjoute;
                Console.WriteLine($"Quantité d'eau dans la citerne apres l'ajout de {litresAjoute} litres: {NiveauRemplissage}/{CapactiteTotale}\n");
            }
            _totalVolumesCiterne += NiveauRemplissage;

        }

        /// <summary>
        /// Retire un nombre donné de litres dans la citerne, 
        /// Print dans la console le resultat de l'operation
        /// </summary>
        /// <param name="litresAjoute">Int correspondant au nombre de litres a retirer</param>
        public void ViderCiterne(int litresRetire)
        {
            _totalVolumesCiterne -= NiveauRemplissage;
            int recup = litresRetire - NiveauRemplissage ;

            if (recup > 0)
            {

                NiveauRemplissage = 0;
                Console.WriteLine($"Quantité d'eau dans la citerne apres le retrait de {litresRetire} litres: {NiveauRemplissage}/{CapactiteTotale}");
                Console.WriteLine($"Quantité d'eau recupere : {recup}\n");
            }
            else
            {
                NiveauRemplissage -= litresRetire;
                Console.WriteLine($"Quantité d'eau dans la citerne apres le retrait de {litresRetire} litres: {NiveauRemplissage}/{CapactiteTotale}\n");
            }
            _totalVolumesCiterne += NiveauRemplissage;
        }

        /// <summary>
        /// Print dans la console la capacité totale de toutes les citernes instanciée
        /// </summary>
        public static void GetCapaciteTotale()
        {
            Console.WriteLine($"Les citernes contiennent au total {_totalVolumesCiterne} litres.\n");
        }

        /// <summary>
        /// Surcharge de la methode Object.ToString()
        /// </summary>
        /// <returns>String decrivant la citerne et ses statistiques</returns>
        public override string ToString()
        {
            return $"La citerne as :\n-  Un poids a vide de {PoidsAVide} litres.\n-  Une capacité totale de {CapactiteTotale} litres.\n-  Un niveau de remplissage de {NiveauRemplissage}/{CapactiteTotale} litres.\n";
        }
    }
}
