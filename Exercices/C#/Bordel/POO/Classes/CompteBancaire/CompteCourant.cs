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
    internal class CompteCourant : CompteBancaire
    {
        // Attributs de classes
        public int NumeroCarteBancaire { get; set; }

        // Constructeur
        public CompteCourant(int numeroCompte, double solde, Client client,int numeroCarteBancaire) : base(numeroCompte, solde, client)
        {
            NumeroCarteBancaire = numeroCarteBancaire;
        }

        /// <summary>
        /// Fait un depot sur le compte. 
        /// </summary>
        /// <param name="montant">Double du montant de l'operation</param>
        public override void Depot(double montant)
        {
            base.Depot(montant);
            Solde += montant;
            FormatSolde();
        }

        /// <summary>
        /// Fait un retrait sur le compte. 
        /// </summary>
        /// <param name="montant">Double du montant de l'operation</param>
        public override void Retrait(double montant)
        {
            base.Retrait(montant);
            Solde -= montant;
            FormatSolde();
        }

        /// <summary>
        /// Override de la methode Object.ToString()
        /// </summary>
        /// <returns>String de la description du compte</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nNumeros de carte bancaire : {NumeroCarteBancaire}";
        }
    }
}
