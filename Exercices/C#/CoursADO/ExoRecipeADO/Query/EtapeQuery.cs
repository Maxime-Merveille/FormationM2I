using ExoRecipeADO.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Query
{
    internal class EtapeQuery : Query
    {
        public static new void Add()
        {
            int rowAffected = 0;

            Console.WriteLine("Entrez la Descriptions de l'Etape:");
            string Descriptions = Console.ReadLine();

            string query = "INSERT INTO Etape(Descriptions) VALUES (@Descriptions);";

            try
            {

                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Descriptions", Descriptions);

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
            string query = "SELECT * FROM Etape;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Etape etape = new Etape(
                            reader.GetInt32("ID"),
                            reader.GetString("Descriptions")
                            );

                        Console.WriteLine(etape);
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
            string query = "SELECT * FROM Etape WHERE Id = @id;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Etape etape = new Etape(
                            reader.GetInt32("ID"),
                            reader.GetString("Descriptions")
                            );

                    Console.WriteLine(etape);
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
            string query = "UPDATE Etape SET Descriptions = @Descriptions WHERE Id = @id;";

            Console.WriteLine("Entrez le nouveau Descriptions de l'Etape:");
            string Descriptions = Console.ReadLine();

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
                cmd.Parameters.AddWithValue("@Descriptions", Descriptions);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nEtape modifié avec succes");
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
            string query = "DELETE FROM Etape WHERE ID = @id;";

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
                    Console.WriteLine("Succes query\nEtape supprimé avec succes");
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
                string queryCheck = "SELECT COUNT(*) FROM Etape WHERE ID = @id;";
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
