using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.CompteBancaire
{
    internal class ComptePayant : CompteBancaire
    {
        public float TauxSurcout { get; set; }


        public ComptePayant(int numeroCompte, double solde, Client client, float tauxSurcout) : base(numeroCompte, solde, client)
        {
            TauxSurcout = tauxSurcout;
        }

        public override void Depot(double montant)
        {
            base.Depot(montant);
            Solde += montant - (montant * TauxSurcout);
            FormatSolde();
        }
        public override void Retrait(double montant)
        {
            double montantEtSurcout = montant + (montant * TauxSurcout);

            base.Retrait(montantEtSurcout);
            Solde -= montantEtSurcout;
            FormatSolde();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTaux de surcout : {TauxSurcout}";
        }
    }
}
