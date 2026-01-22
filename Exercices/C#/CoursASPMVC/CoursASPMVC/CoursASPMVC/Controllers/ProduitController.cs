using CoursASPMVC.Data;
using CoursASPMVC.Models;
using CoursASPMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoursASPMVC.Controllers
{
    public class ProduitController : Controller
    {
        private ProduitService service = new ProduitService();

        public IActionResult Index()
        {
            List<Produit> listProduit = service.GetAllProduit();
            if(listProduit == null) return View();
            else return View(listProduit);

        }

        public IActionResult Detail(int Id)
        {
           Produit produit = service.GetProduitById(Id);


            return View(produit);
        }

        public IActionResult Add()
        {
              
            return View();
        }

        public IActionResult ConfirmAdd([Bind("Nom,Prix,Stock")] Produit produit)
        {
            service.AddProduit(produit);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            
            return View(service.GetProduitById(Id));
        }

        public IActionResult ConfirmUpdate([Bind("Id,Nom,Prix,Stock")] Produit produit)
        {
            service.UpdateProduit(produit);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            service.DeleteProduit(Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
