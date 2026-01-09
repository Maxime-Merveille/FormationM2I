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
    internal class Paypal : IPaiement
    {
        // Attribut du compte Paypal
        public string AdresseMail { get; set; }
        public string MDP { get; set; }
        public double Solde { get; set; }

        // Constructeur
        public Paypal(string adresseMail, string mdp, double solde)
        {
            AdresseMail = adresseMail;
            MDP = mdp;
            Solde = solde;
        }

        /// <summary>
        /// Methode de paiement 
        /// </summary>
        /// <param name="Montant">Double du montant du paiement </param>
        /// <returns>String d'info sur la transaction</returns>
        public string EffectuerPaiement(double Montant)
        {
            if (Solde < Montant) {
                return "Echec du paiement PayPal de " + Montant + " euros.\nSolde insuffisant.";
            }
            else
            {
                Solde -= Montant;
                return "Paiement PayPal de " + Montant + " euros effectue.\nVotre solde est de :" + Solde + " euros.";
            }
                
        }
    }
}
