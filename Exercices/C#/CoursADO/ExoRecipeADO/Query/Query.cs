using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Query
{
    internal abstract class Query
    {
        public static string connectionString = "Server=localhost;Database=recipe;User ID=root;Password=formation";

        public static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void Add()
        {

        }

        public static void GetAll()
        {

        }

        public static void GetById(int id)
        {

        }

        public static void Update(int id)
        {

        }

        public static void Delete(int id)
        {

        }
    }
}
