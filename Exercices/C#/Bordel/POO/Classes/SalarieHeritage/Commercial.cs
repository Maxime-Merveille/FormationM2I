using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.SalarieHeritage
{
    internal class Commercial : SalarieHeritage
    {
        public double ChiffreAffaire { get; set; }
        public float PrctCommission { get; set; }


        private Commercial() : base(){ } 

        public Commercial(int matricule, string service, string categorie, string nom, double salaire, double CA, float commission) : base(matricule,service,categorie, nom, salaire)
        {
            ChiffreAffaire = CA; 
            PrctCommission = commission;
        }

        public override void AfficherSalaire()
        {
            double? salaireReel = Salaire + (ChiffreAffaire * PrctCommission);
            Console.WriteLine($"Le salaire de {Nom}, Matricule : {Matricule} est de {salaireReel} euros");
        }

        public override string ToString()
        {
            return base.ToString() + $",\n Chiffre d'affaire {ChiffreAffaire},\n Commission en % {PrctCommission}";
        }
    }
}
