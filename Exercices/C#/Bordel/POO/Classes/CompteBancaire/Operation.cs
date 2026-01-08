using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.CompteBancaire
{
    public enum Status
    {
        Depot,
        Retrait
    }

    internal class Operation
    {
        public int NumeroOperation { get; set; }
        public double Montant { get; set; }
        public Status StatusOpe { get; set; }

        public Operation(int numeroOperation,double montant, Status statu ) 
        {
            NumeroOperation = numeroOperation;
            Montant = montant;  
            StatusOpe = statu;
        }

        public override string ToString()
        {
            return "\n"+base.GetType().Name + $" n° {NumeroOperation} | Montant : {Montant} | Status {StatusOpe}";
        }
        
    }
}
