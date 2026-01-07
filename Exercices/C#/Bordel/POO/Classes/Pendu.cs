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
    internal class Pendu
    {
        public string Masque { get; set; }
        public string MotCache { get; set; }
        public int NbEssai { get; set; }


        private Pendu()
        {
            MotCache = GenerateurMots.GenererMot();
        }
        public Pendu(int essai) : this()
        {
            NbEssai = essai;
            GenererMasque();
        }

        /// <summary>
        /// Generation du masque en debut de partie
        /// </summary>
        /// <returns>Masque format string</returns>
        public string GenererMasque()
        {
            for(int i = 0; i < MotCache.Length; i++)
            {
                Masque += "*";
            }
            return Masque;
        }

        /// <summary>
        /// Test si le caractere existe en un ou plusieurs exemplaire dans le jeu 
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Masque en format string</returns>
        public string TestChar(char c)
        {
            //Changer les string char array, C# est chiant sur les string 
            char[] arrayMasque = Masque.ToCharArray();
            char[] arrayMotCache = MotCache.ToCharArray();
            bool trouve = false;

            for (int i = 0; i < arrayMotCache.Length; i++)
            {
                if (arrayMotCache[i] == c)
                {
                    arrayMasque[i] = c;
                    trouve = true;
                }
            }

            if (!trouve) NbEssai--;

            Masque = string.Join("",arrayMasque);
            return Masque;
        }

        /// <summary>
        /// Test si le joueur a trouver le mot
        /// </summary>
        /// <returns>Boolean</returns>
        public bool TestWin()
        {
            if(Masque == MotCache) return true;
            else return false;
        }
    }
}
