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

using ExoContactEF.Controllers;
using ExoContactEF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoContactEF.Views
{
    internal class ContactView
    {
        // instance du contactController
        public static ContactController contactController = new ContactController();

        /// <summary>
        /// Impression du Menu de choix utilisateurs
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("\n===== Menu ===== \n");
            Console.WriteLine("1 - Ajouter un contact");
            Console.WriteLine("2 - Recuperer tout les contacts");
            Console.WriteLine("3 - Recuperer un contact par Id");
            Console.WriteLine("4 - Recuperer un contact par Nom");
            Console.WriteLine("5 - Recuperer un contact par Email");
            Console.WriteLine("6 - Modifier un contact par Id");
            Console.WriteLine("7 - Supprimer un contact par Id");
            Console.WriteLine("Autre - Quitter l'appli");
        }

        /// <summary>
        /// Recupere les info contact pour creer un nouveaux contact
        /// </summary>
        /// <returns>Nouvel objet contact </returns>
        private static Contact GetInfoContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Entrez le nom : ");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Entrez le prenom : ");
            contact.Surname = Console.ReadLine();
            Console.WriteLine("Entrez l'age : ");
            contact.Age = Int32.Parse(Console.ReadLine());
            contact.DateOfBirth = DateTime.Now;
            Console.WriteLine("Entrez le num de telephone : ");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Entrez le mail : ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Entrez le genre : ");
            contact.Gender = Console.ReadLine().ElementAt(0);

            return contact;
        }

        /// <summary>
        /// Recupere et alimente le nouvel objet contact a modifier en BDD
        /// </summary>
        /// <param name="contact">Contact vierge a modifier</param>
        /// <returns>Contact modifier a envoyer en BDD</returns>
        private static Contact GetUpdateContact(Contact contact)
        {
            Console.WriteLine("Entrez le nom : ");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Entrez le prenom : ");
            contact.Surname = Console.ReadLine();
            Console.WriteLine("Entrez l'age : ");
            contact.Age = Int32.Parse(Console.ReadLine());
            contact.DateOfBirth = DateTime.Now;
            Console.WriteLine("Entrez le num de telephone : ");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Entrez le mail : ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Entrez le genre : ");
            contact.Gender = Console.ReadLine().ElementAt(0);#if
            *

            return contact;
        }

        /// <summary>
        /// Imprime en console tout les elements de la liste
        /// </summary>
        /// <param name="list">Liste de contact</param>
        private static void PrintList(List<Contact> list)
        {
            foreach (Contact contact in list)
            {
                Console.WriteLine(contact);
            }
        }

        /// <summary>
        /// IHM principale de gestion de contact
        /// </summary>
        public static void InitIHM()
        {
            Console.WriteLine("########### Appli de contacts ###########\n\n");
            Contact contact = new Contact();
            List<Contact> listContact = new List<Contact>();
            int id = 0;
            bool continuer = true;

            while (continuer)
            {
                PrintMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        contact = GetInfoContact();
                        contactController.AddContact(contact);
                        break;

                    case "2":

                       listContact = contactController.GetAllContact();
                        PrintList(listContact);

                        break;

                    case "3":

                        Console.WriteLine("Entrez l'Id du contact");
                        id = Int32.Parse(Console.ReadLine());

                        Console.WriteLine(contactController.GetContactById(id));
                        
                        break;

                    case "4":

                        Console.WriteLine("Entrez le nom du contact");
                        string name = Console.ReadLine();

                        listContact = contactController.GetContactByName(name);
                        PrintList(listContact);
                        break;

                    case "5":
                        Console.WriteLine("Entrez l'email du contact");
                        string mail = Console.ReadLine();

                        Console.WriteLine(contactController.GetContactByEmail(mail));

                        break;

                    case "6":
                        Console.WriteLine("Entrez l'Id du contact");
                        id = Int32.Parse(Console.ReadLine());

                        contact = contactController.GetContactById(id);

                        Console.WriteLine("Entrez les nouvelles infos du contact");
                        contact = GetUpdateContact(contact);

                        contactController.UpdateContact(contact);

                        break;

                    case "7":
                        Console.WriteLine("Entrez l'Id du contact a supprimer");
                        id = Int32.Parse(Console.ReadLine());

                        contactController.DeleteContactById(id);

                        break;

                    default:
                        continuer = false;
                        break;
                }
            }

        }
    }
}
