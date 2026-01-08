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


        public Client(string nom, string prenom, int id, int numTel)
        {
            ListeComptesBancaire = new List<CompteBancaire>(); // Init de la liste
            Nom = nom;
            Prenom = prenom;
            Identifiant = id;
            NumeroTelephone = numTel;
        }

        public void AddCompteBancaire(CompteBancaire compte)
        {
            ListeComptesBancaire.Add(compte);
        }

        public void NewDepotParIdCompte(int idCompte, double montant)
        {
            ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte).Depot(montant);
        }
        public void NewRetraitParIdCompte(int idCompte, double montant)
        {
            ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte).Retrait(montant);
        }

        public CompteBancaire GetCompteBancaireById(int idCompte)
        {
            return ListeComptesBancaire.First(cpt => cpt.NumeroCompte == idCompte);
        }

        public void PrintAllCompteBancaire()
        {
            foreach(CompteBancaire cpt in ListeComptesBancaire)
            {
                Console.WriteLine(cpt);
            }
        }

        public override string ToString()
        {
            return $"Nom : {Nom} {Prenom}\nIdentifiant : {Identifiant}\nNumero de telephone : {NumeroTelephone}\nNombre de comptes {ListeComptesBancaire.Count}";
        }
    }
}
