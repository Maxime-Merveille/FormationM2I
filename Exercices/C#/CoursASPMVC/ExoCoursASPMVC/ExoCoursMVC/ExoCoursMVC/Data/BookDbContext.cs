using ExoCoursMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoCoursMVC.Data
{
    public class BookDbContext : DbContext
    {
        // DbSet des contact
        public DbSet<Book> Books { get; set; }

        // Configuration de la connection BDD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=DbExoMVC;user=root;password=formation;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
