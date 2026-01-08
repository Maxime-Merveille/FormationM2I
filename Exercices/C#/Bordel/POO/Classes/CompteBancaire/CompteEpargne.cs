using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.CompteBancaire
{
    internal class CompteEpargne : CompteBancaire
    {
        public float TauxEpargne { get; set; }


        public CompteEpargne(int numeroCompte, double solde, Client client, float tauxEpargne) : base(numeroCompte, solde, client)
        {
            TauxEpargne = tauxEpargne;
        }

        public override void Depot(double montant)
        {
            double MontantAvecEpargne = montant + (montant * TauxEpargne);

            base.Depot(MontantAvecEpargne);
            Solde += MontantAvecEpargne;
            FormatSolde();
        }

        public override void Retrait(double montant)
        {
          
            Solde -= montant;
            FormatSolde();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTaux d'epargne : {TauxEpargne}";
        }
    }
}
