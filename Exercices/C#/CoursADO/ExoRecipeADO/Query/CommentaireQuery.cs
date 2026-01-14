using ExoRecipeADO.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Query
{
    internal class CommentaireQuery : Query
    {
        public static new void Add()
        {
            int rowAffected = 0;

            Console.WriteLine("Entrez la Descriptions du Commentaire:");
            string Descriptions = Console.ReadLine();

            string query = "INSERT INTO Commentaire(Descriptions) VALUES (@Descriptions);";

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
            string query = "SELECT * FROM Commentaire;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Commentaire com = new Commentaire(
                            reader.GetInt32("ID"),
                            reader.GetString("Descriptions")
                            );

                        Console.WriteLine(com);
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
            string query = "SELECT * FROM Commentaire WHERE Id = @id;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Commentaire com = new Commentaire(
                            reader.GetInt32("ID"),
                            reader.GetString("Descriptions")
                            );

                    Console.WriteLine(com);
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
            string query = "UPDATE Commentaire SET Descriptions = @Descriptions WHERE Id = @id;";

            Console.WriteLine("Entrez le nouveau Descriptions du Commentaire:");
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
                    Console.WriteLine("Succes query\nCommentaire modifié avec succes");
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
            string query = "DELETE FROM Commentaire WHERE ID = @id;";

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
                    Console.WriteLine("Succes query\nCommentaire supprimé avec succes");
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
                string queryCheck = "SELECT COUNT(*) FROM Commentaire WHERE ID = @id;";
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
