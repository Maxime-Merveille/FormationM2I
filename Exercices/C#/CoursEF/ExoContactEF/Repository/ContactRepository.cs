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

using ExoContactEF.Data;
using ExoContactEF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoContactEF.Repository
{
    internal class ContactRepository
    {

        /// <summary>
        /// Recupere un contact unique par Id
        /// </summary>
        /// <param name="id">Id unique du contact</param>
        /// <returns>Objet Contact</returns>
        public static Contact GetContactById(int id)
        {
            Contact contact;
            using (var db = new AppDbContext())
            {
                contact = db.Contacts.Find(id);

                if (contact != null)
                {
                    return contact;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupere une liste de contacts correspondant au Nom
        /// </summary>
        /// <param name="name">Nom du contact</param>
        /// <returns>Liste d'Objet Contact</returns>
        public static List<Contact> GetContactByName(string name)
        {
            List<Contact> contacts;
            using (var db = new AppDbContext())
            {
                contacts = db.Contacts.Where(c => c.Name.Contains(name)).ToList();

                if (contacts != null)
                {
                    return contacts;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupere un contact unique par email
        /// </summary>
        /// <param name="email">email unique du contact</param>
        /// <returns>Objet Contact</returns>
        public static Contact GetContactByEmail(string email)
        {
            Contact contact;
            using (var db = new AppDbContext())
            {
                contact = db.Contacts.Where(c => c.Email.Equals(email)).FirstOrDefault();

                if (contact != null)
                {
                    return contact;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Recupere tout les contacts
        /// </summary>
        /// <returns>Liste d'Objet Contact</returns>
        public static List<Contact> GetAllContact()
        {
            List<Contact> contacts;
            using (var db = new AppDbContext())
            {
                contacts = db.Contacts.ToList();

                if (contacts != null)
                {
                    return contacts;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Ajouter un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a ajouter en BDD</param>
        public static void AddContact(Contact contact)
        {

            using (var db = new AppDbContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

            }
        }

        /// <summary>
        /// Modifie un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a modifier en BDD</param>
        public static void UpdateContact(Contact contact)
        {
            using (var db = new AppDbContext())
            {
                db.Contacts.Update(contact);
                db.SaveChanges();

            }
        }

        /// <summary>
        /// Supprime un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a supprimer de la BDD</param>
        public static void DeleteContactById(int id)
        {
            using (var db = new AppDbContext())
            {
                Contact contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();

            }
        }
    }
}
