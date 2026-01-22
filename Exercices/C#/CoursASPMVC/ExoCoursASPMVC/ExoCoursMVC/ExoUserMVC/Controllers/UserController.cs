using Microsoft.AspNetCore.Mvc;

namespace ExoUserMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("Id invalide");
            }
            else if (Id > 100) {
                return NotFound("Utilisateur inexistant");
            }
            ViewData["Titre"] = $"Id : {Id}, truc muche machin";
            return View();
        }

        public IActionResult GetUserJson(int Id) {

            if (Id <= 0)
            {
                return BadRequest("Id invalide");
            }
            else if (Id > 100)
            {
                return NotFound("Utilisateur inexistant");
            }
            
            return Json(new { Id = Id, nom = "Shrek", email = "Degage de mon marais"});
        }


        public IActionResult Create()
        {
            //Effectuer creation

            return RedirectToAction("Index");
        }

        public IActionResult AdminPanel(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("Id invalide");
            }
            else if (Id > 100)
            {
                return NotFound("Utilisateur inexistant");
            }
            else if(Id != 1)
            {
                return Forbid("Vous navez pas les droits");
            }
            return View();
        }
    }
}
