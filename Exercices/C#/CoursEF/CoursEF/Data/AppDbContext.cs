using CoursEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursEF.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            //Exemple connection string 
            string connectionString = "server=localhost;database=demo_efcore;user=root;password=formation;";

            // Methode de connection a la DB
            optionBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


    }
}
