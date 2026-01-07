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
    internal class Chaise
    {
        // Declaration des variables + getter setter
        public int NombrePied { get; set; }
        public string Materiaux { get; set; }
        public string Couleur {  get; set; }

        //Constructeur par defaut
        public Chaise() {
            NombrePied = 4;
            Materiaux = "Bois";
            Couleur = "Blanche";
        }

        //Constructeur avec variables d'initialisation personnalisée
        public Chaise(int nbPieds, string materiaux, string couleur)
        {
            NombrePied = nbPieds;
            Materiaux = materiaux;
            Couleur = couleur;

        }

        /// <summary>
        /// Methode surchargé permettant a renvoyer le descriptif de l'objet
        /// Surcharge de la methode .ToString() de la classe object
        /// Ne prends aucun parametres
        /// </summary>
        /// <returns>string de description de la chaise</returns>
        public override string ToString()
        {
            return $"Je suis une Chaise, avec {NombrePied} pieds en {Materiaux} et de couleur {Couleur}.";
        }
    }
}
