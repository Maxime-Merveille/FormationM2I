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
using ExoContactEF.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ExoContactEF.Controllers
{
    internal class ContactController
    {
        // Constructeur
        public ContactController() { }

        /// <summary>
        /// Recupere un contact unique par Id
        /// </summary>
        /// <param name="id">Id unique du contact</param>
        /// <returns>Objet Contact</returns>
        public Contact GetContactById(int id)
        {
            return ContactRepository.GetContactById(id);
        }

        /// <summary>
        /// Recupere une liste de contacts correspondant au Nom
        /// </summary>
        /// <param name="name">Nom du contact</param>
        /// <returns>Liste d'Objet Contact</returns>
        public List<Contact> GetContactByName(string name)
        {
            return ContactRepository.GetContactByName(name);
        }

        /// <summary>
        /// Recupere un contact unique par email
        /// </summary>
        /// <param name="email">email unique du contact</param>
        /// <returns>Objet Contact</returns>
        public Contact GetContactByEmail(string email)
        {
            return ContactRepository.GetContactByEmail(email);
        }

        /// <summary>
        /// Recupere tout les contacts
        /// </summary>
        /// <returns>Liste d'Objet Contact</returns>
        public List<Contact> GetAllContact()
        {
            return ContactRepository.GetAllContact();
        }

        /// <summary>
        /// Ajouter un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a ajouter en BDD</param>
        public void AddContact(Contact contact)
        {
            ContactRepository.AddContact(contact);
        }

        /// <summary>
        /// Modifie un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a modifier en BDD</param>
        public void UpdateContact(Contact contact)
        {
            ContactRepository.UpdateContact(contact);
        }

        /// <summary>
        /// Supprime un objet contact en BDD
        /// </summary>
        /// <param name="contact">Objet contact a supprimer de la BDD</param>
        public void DeleteContactById(int id) 
        {
            ContactRepository.DeleteContactById(id);
        }
    }
}
