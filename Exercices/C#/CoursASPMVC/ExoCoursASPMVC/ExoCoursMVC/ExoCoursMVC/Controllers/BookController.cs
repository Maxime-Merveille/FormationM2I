using ExoCoursMVC.Models;
using ExoCoursMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;

namespace ExoCoursMVC.Controllers
{
    public class BookController : Controller
    {
        private BookService service = new BookService();

        public IActionResult Index()
        {
            List<Book> listBook = service.GetAll();
            if (listBook == null) return View();
            else return View(listBook);

        }

        public IActionResult Detail(int Id)
        {
            Book Book = service.GetById(Id);


            return View(Book);
        }

        public IActionResult Add()
        {

            return View();
        }

        public IActionResult ConfirmAdd([Bind("Titre,Genre,Stock")] Book Book)
        {
            service.Add(Book);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {

            return View(service.GetById(Id));
        }

        public IActionResult ConfirmUpdate([Bind("Id,Titre,Genre,Stock")] Book Book)
        {
            service.Update(Book);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            service.Delete(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Genre(string inputGenre)
        {
            return View(service.GetByGenre(inputGenre));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
