using System;
using System.Collections.Generic;
using System.Text;

namespace CoursADO.Classes
{
    internal class Personne
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Personne() { }

        public Personne(string nom, string prenom, int age, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Email = email;
        }

        public Personne(int id ,string nom, string prenom, int age, string email) : this(nom, prenom, age, email) 
        {
            ID = id;
        }

        public override string ToString()
        {
            return $"Id : {ID}, {Prenom} {Nom}, Age : {Age}, Email : {Email}";
        }
    }
}
