using ExoRecipeADO.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Query
{
    internal class CategorieQuery : Query
    {
        public static new void Add()
        {
            int rowAffected = 0;

            Console.WriteLine("Entrez Nom de la categorie:");
            string nom = Console.ReadLine();

            string query = "INSERT INTO Categorie(Nom) VALUES (@nom);";
            
            try
            {

                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nom", nom);

                rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }


        public static new void GetAll()
        {
            string query = "SELECT * FROM Categorie;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Categorie cat = new Categorie(
                            reader.GetInt32("ID"),
                            reader.GetString("Nom")
                            );

                        Console.WriteLine(cat);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static new void GetById(int Id)
        {
            string query = "SELECT * FROM Categorie WHERE Id = @id;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Categorie cat = new Categorie(
                            reader.GetInt32("ID"),
                            reader.GetString("Nom")
                            );

                    Console.WriteLine(cat);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static new void Update(int Id)
        {
            string query = "UPDATE Categorie SET Nom = @nom WHERE Id = @id;";

            Console.WriteLine("Entrez le nouveau nom de la categorie:");
            string nom = Console.ReadLine();

            try
            {
                connection.Open();

                if (!CheckIfExist(Id))
                {
                    Console.WriteLine("Cet ID n'existe pas");
                    return;
                }            

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@nom", nom);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nCategorie modifié avec succes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static new void Delete(int Id)
        {
            string query = "DELETE FROM Categorie WHERE ID = @id;";

            try
            {
                connection.Open();

                if (!CheckIfExist(Id))
                {
                    Console.WriteLine("Cet ID n'existe pas");
                    return;
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nCategorie supprimé avec succes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static bool CheckIfExist(int id)
        {
            int count = 0;
            try
            {
                string queryCheck = "SELECT COUNT(*) FROM Categorie WHERE ID = @id;";
                MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
                cmdCheck.Parameters.AddWithValue("@id", id);

                count = Convert.ToInt32(cmdCheck.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return count != 0;
        }
    }
}
