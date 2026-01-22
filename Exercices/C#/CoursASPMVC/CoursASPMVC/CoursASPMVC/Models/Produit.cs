namespace CoursASPMVC.Models
{
    public class Produit
    {
        public int Id {  get; set; }
        public string Nom {  get; set; }
        public double Prix {  get; set; }
        public int Stock {  get; set; }
    
        
        public bool IsAvailable => Stock > 0;
        
        
    }
}
