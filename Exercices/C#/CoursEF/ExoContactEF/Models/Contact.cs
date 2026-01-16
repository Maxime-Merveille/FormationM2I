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
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExoContactEF.Models
{
    internal class Contact
    {

        // Attributs de classe

        // Id Unique (Primary key)
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; } 

        public int Age {  get; set; }

        public DateTime DateOfBirth {get; set;}

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public char Gender { get; set; }


        // Constructeur
        public Contact() { }


        public Contact(string name, string surname, int age, DateTime dob, string phone, string mail, char gender) 
        {
            Name = name;
            Surname = surname;
            Age = age;
            DateOfBirth = dob;
            PhoneNumber = phone;
            Email = mail;
            Gender = gender;
        
        }

        /// <summary>
        /// Oerride de la methode ToString pour decrire l'objet
        /// </summary>
        /// <returns>String de la description de l'objet</returns>
        public override string ToString()
        {
            return $"Id {Id} | Nom {Name} | Prenom {Surname} | Age {Age} | date de naiss {DateOfBirth} | tel {PhoneNumber} | Email {Email} | genre {Gender}";
        }

    }
}
