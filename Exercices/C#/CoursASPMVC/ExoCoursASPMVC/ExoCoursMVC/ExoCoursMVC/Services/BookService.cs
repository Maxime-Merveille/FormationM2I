using ExoCoursMVC.Data;
using ExoCoursMVC.Data.Repository;
using ExoCoursMVC.Models;
using System;

namespace ExoCoursMVC.Services
{
    public class BookService
    {
        public Book GetById(int id)
        {
            Book book = BookRepository
                .GetAll()
                .FirstOrDefault(b => b.Id == id);
            return book;
        }

        /// <summary>
        /// Recupere une liste de Books correspondant au Nom
        /// </summary>
        /// <param Titre="Titre">Nom du Book</param>
        /// <returns>Liste d'Objet Book</returns>
        public List<Book> GetByGenre(string Genre)
        {
            List<Book> books = BookRepository
                .GetAll()
                .Where(b => b.Genre == Genre)
                .ToList();

            return books;
        }

        /// <summary>
        /// Recupere tout les Books
        /// </summary>
        /// <returns>Liste d'Objet Book</returns>
        public List<Book> GetAll()
        {
            List<Book> Books = BookRepository
            .GetAll()
            .OrderBy(b => b.Titre)
            .ToList();

            return Books;
        }

        /// <summary>
        /// Ajouter un objet Book en BDD
        /// </summary>
        /// <param Titre="Book">Objet Book a ajouter en BDD</param>
        public void Add(Book Book)
        {
            BookRepository.Add(Book);


        }

        /// <summary>
        /// Modifie un objet Book en BDD
        /// </summary>
        /// <param Titre="Book">Objet Book a modifier en BDD</param>
        public void Update(Book Book)
        {
            BookRepository.Update(Book);
        }

        /// <summary>
        /// Supprime un objet Book en BDD
        /// </summary>
        /// <param Titre="Book">Objet Book a supprimer de la BDD</param>
        public void Delete(int id)
        {
            Book book = GetById(id);
            BookRepository.Delete(book);
        }
    }
}
