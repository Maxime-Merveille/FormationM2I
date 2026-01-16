using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoursEF.Models
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int ClassNumber { get; set; }
        
        public DateTime DateDiplome { get; set; }

        public Student() { }

        public Student(string name, int classNum, DateTime dateDiplome)
        {
            Name = name;
            ClassNumber = classNum;
            DateDiplome = dateDiplome;
        }

        public override string ToString()
        {
            return  $"ID : {Id}| Nom : {Name}, Classe n°{ClassNumber}";
        }
    }
}
