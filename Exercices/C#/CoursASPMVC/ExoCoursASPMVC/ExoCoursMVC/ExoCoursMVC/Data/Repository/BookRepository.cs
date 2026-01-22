using ExoCoursMVC.Models;

namespace ExoCoursMVC.Data.Repository
{
    public class BookRepository
    {

        public static List<Book> GetAll()
        {
            List<Book> Books;
            using (var db = new BookDbContext())
            {
                Books = db.Books.ToList();

                if (Books != null)
                {
                    return Books;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Add(Book Book)
        {

            using (var db = new BookDbContext())
            {
                db.Books.Add(Book);
                db.SaveChanges();

            }
        }

        public static void Update(Book Book)
        {
            using (var db = new BookDbContext())
            {
                db.Books.Update(Book);
                db.SaveChanges();

            }
        }


        public static void Delete(Book book)
        {
            using (var db = new BookDbContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();

            }
        }
    }
}
