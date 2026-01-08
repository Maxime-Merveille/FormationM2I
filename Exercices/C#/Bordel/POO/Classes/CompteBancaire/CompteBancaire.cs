using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace POO.Classes.CompteBancaire
{
    internal abstract class CompteBancaire
    {
        // Randomizer pour les ID d'operation, pourquoi pas :)
        private Random rand = new Random();

        // Attributs Comptes bancaire
        public int NumeroCompte { get; set; }
        public double Solde { get; set; }
        public Client client { get; set; }
        public List<Operation> operations { get; set; }


        // Constructeur
        public CompteBancaire(int numeroCompte, double solde, Client client)
        {
            operations = new List<Operation>(); // Init de la liste
            NumeroCompte = numeroCompte;
            Solde = solde;
            this.client = client;
        }

        /// <summary>
        /// Retourne l'operation demandé via ID
        /// </summary>
        /// <param name="id">Int correspondant a l'identifiant de l'operation</param>
        /// <returns>Objet de type Operation</returns>
        public Operation GetOperationById(int id)
        {
            return operations.First(ope => ope.NumeroOperation == id);
        }

        /// <summary>
        /// Print en console toutes les operation de ce compte
        /// </summary>
        public void PrintAllOperation()
        {
            foreach (Operation operation in operations)
            {
                Console.WriteLine(operation);
            }
        }

        /// <summary>
        /// Retourne le solde du compte
        /// </summary>
        /// <returns>double correspondant au solde du compte</returns>
        public double GetSolde()
        {
            return Solde; 
        }

        /// <summary>
        /// Effectuer un depot d'argent sur le compte
        /// </summary>
        /// <param name="montant">double du montant de l'operation</param>
        public virtual void Depot(double montant)
        {
            Operation ope = new Operation(rand.Next(1000,9999), montant, Status.Depot);
            operations.Add(ope);
        }

        /// <summary>
        /// Effectuer un retrait d'argent sur le compte
        /// </summary>
        /// <param name="montant">double du montant de l'operation</param>
        public virtual void Retrait(double montant)
        {
            Operation ope = new Operation(rand.Next(1000, 9999), montant, Status.Retrait);
            operations.Add(ope);
        }

        /// <summary>
        /// Override de la methode Object.ToString()
        /// </summary>
        /// <returns>String contenant la description du compte</returns>
        public override string ToString()
        {
            return "\n"+base.GetType().Name +  $"\nNumeroCompte : {NumeroCompte}\nSolde : {Solde}\nNombre d'operation : {operations.Count}";
        }

        /// <summary>
        /// Formatage du solde sur 2 decimales
        /// </summary>
        public void FormatSolde()
        {
            this.Solde = Math.Round(this.Solde, 2);
        }
    }
}
