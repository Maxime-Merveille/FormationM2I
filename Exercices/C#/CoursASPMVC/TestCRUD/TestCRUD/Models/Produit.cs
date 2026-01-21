namespace TestCRUD.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Stock { get; set; }
        public double Prix { get; set; }


        public Produit() { }

        public Produit(int id, string nom, int stock, double prix)
        {
            Id = id;
            Nom = nom;
            Stock = stock;
            Prix = prix;
        }
    }
}
