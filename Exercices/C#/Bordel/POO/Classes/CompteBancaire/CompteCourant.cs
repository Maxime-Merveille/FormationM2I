using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.CompteBancaire
{
    internal class CompteCourant : CompteBancaire
    {
        public int NumeroCarteBancaire { get; set; }

        public CompteCourant(int numeroCompte, double solde, Client client,int numeroCarteBancaire) : base(numeroCompte, solde, client)
        {
            NumeroCarteBancaire = numeroCarteBancaire;
        }

        public override void Depot(double montant)
        {
            base.Depot(montant);
            Solde += montant;
            FormatSolde();
        }

        public override void Retrait(double montant)
        {
            base.Retrait(montant);
            Solde -= montant;
            FormatSolde();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nNumeros de carte bancaire : {NumeroCarteBancaire}";
        }
    }
}
