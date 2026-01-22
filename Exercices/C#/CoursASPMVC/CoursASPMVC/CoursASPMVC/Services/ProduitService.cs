using CoursASPMVC.Data;
using CoursASPMVC.Models;

namespace CoursASPMVC.Services
{
    public class ProduitService
    {
        public List<Produit> produitsList { get; set; }
        public ProduitService() {} 


        public void AddProduit(Produit produit)
        {
            using (var db = new AppDbContext())
            {
                db.Produits.Add(produit);
                db.SaveChanges();

            }
        }

        public Produit GetProduitById(int produitId)
        {
            Produit produit;
            using (var db = new AppDbContext())
            {
                produit = db.Produits.Find(produitId);

                if (produit != null)
                {
                    return produit;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Produit> GetAllProduit()
        {
            List<Produit> produits;
            using (var db = new AppDbContext())
            {
                produits = db.Produits.ToList();

                if (produits != null)
                {
                    return produits;
                }

                else
                {
                    return null;
                }
            }
        }

        public void UpdateProduit(Produit produit) {

            using (var db = new AppDbContext())
            {
                db.Produits.Update(produit);
                db.SaveChanges();

            }
        }

        public void DeleteProduit(int produitId) {

            using (var db = new AppDbContext())
            {
                Produit produit = db.Produits.Find(produitId);
                db.Produits.Remove(produit);
                db.SaveChanges();
            }
        }
    }
}
