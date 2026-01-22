using CoursASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursASPMVC.Data
{
    public class AppDbContext : DbContext
    {
        // DbSet des contact
        public DbSet<Produit> Produits { get; set; }

        // Configuration de la connection BDD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=mvc_app;user=root;password=formation;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
