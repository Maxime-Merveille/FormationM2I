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
    internal class Client
    {
        // Attributs client
        public string Nom { get; set; }
        public string Prenom {  get; set; }
        public int Identifiant { get; set; }
        public List<CompteBancaire> ListeComptesBancaire { get; set;  }
        public int NumeroTelephone {  get; set; }

        // Constructeur
        public Client(string nom, string prenom, int id, int numTel)
        {
            ListeComptesBancaire = new List<CompteBancaire>(); // Init de la liste
            Nom = nom;
            Prenom = prenom;
            Identifiant = id;
            NumeroTelephone = numTel;
        }

        /// <summary>
        /// Ajout d'un compte bancaire CompteBancaire() dans la liste ListeCompteBancaire
        /// </summary>
        /// <param name="compte">Compte bancaire de type CompteBancaire()</param>
        public void AddCompteBancaire(CompteBancaire compte)
        {
            ListeComptesBancaire.Add(compte);
        }

        /// <summary>
        /// Creer un nouveau depot sur un compte definis par ID
        /// </summary>
        /// <param name="idCompte">Int de l'ID du compte ou effectuer l'operation</param>
        /// <param name="montant">Double montant de l'operation</param>
        public void NewDepotParIdCompte(int idCompte, double montant)
        {
            ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte).Depot(montant);
        }

        /// <summary>
        /// Creer un nouveau retrait sur un compte definis par ID
        /// </summary>
        /// <param name="idCompte">Int de l'ID du compte ou effectuer l'operation</param>
        /// <param name="montant">Double montant de l'operation</param>
        public void NewRetraitParIdCompte(int idCompte, double montant)
        {
            ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte).Retrait(montant);
        }

        /// <summary>
        /// Recupere le compte bancaire correspondant a l'identifiant donne
        /// </summary>
        /// <param name="idCompte">Int de l'identifiant du compte</param>
        /// <returns>Objet de type CompteBancaire() </returns>
        public CompteBancaire GetCompteBancaireById(int idCompte)
        {
            return ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte);
        }

        /// <summary>
        /// Imprime en console tous les compte bancaire de ce client 
        /// </summary>
        public void PrintAllCompteBancaire()
        {
            foreach(CompteBancaire cpt in ListeComptesBancaire)
            {
                Console.WriteLine(cpt);
            }
        }

        /// <summary>
        /// Override de la methode Object.ToString()
        /// </summary>
        /// <returns>String de la description du client</returns>
        public override string ToString()
        {
            return $"Nom : {Nom} {Prenom}\nIdentifiant : {Identifiant}\nNumero de telephone : {NumeroTelephone}\nNombre de comptes {ListeComptesBancaire.Count}";
        }
    }
}
