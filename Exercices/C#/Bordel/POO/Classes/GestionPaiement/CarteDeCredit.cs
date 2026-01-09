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

namespace POO.Classes.GestionPaiement
{
    internal class CarteDeCredit : IPaiement
    {

        // Attribut de la carte de credit
        public int Numero { get; set; }
        public string Titulaire { get; set; }
        public DateTime DateExpiration { get; set; }
        public int CodeCCV { get; set; }
        public double Solde { get; set; }

        // Constructeur
        public CarteDeCredit(int numero, string titulaire, DateTime dateExp, int codeCCV, double solde)
        {
            Numero = numero;
            Titulaire = titulaire;
            DateExpiration = dateExp;
            CodeCCV = codeCCV;
            Solde = solde;
        }

        /// <summary>
        /// Methode de paiement 
        /// </summary>
        /// <param name="Montant">Double du montant du paiement </param>
        /// <returns>String d'info sur la transaction</returns>
        public string EffectuerPaiement(double Montant)
        {
            if (Solde < Montant)
            {
                return "Echec du paiement par carte de credit de " + Montant + " euros.\nSolde insuffisant.";
            }
            else
            {
                Solde -= Montant;
                return "Paiement carte de credit de " + Montant + " euros effectue.\nVotre solde est de :" + Solde + " euros.";
            }
            
        }
    }
}
