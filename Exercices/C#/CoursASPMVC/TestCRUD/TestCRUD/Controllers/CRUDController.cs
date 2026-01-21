using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestCRUD.Models;

namespace TestCRUD.Controllers
{
    public class CRUDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Add()
        {

        }
    }
}
