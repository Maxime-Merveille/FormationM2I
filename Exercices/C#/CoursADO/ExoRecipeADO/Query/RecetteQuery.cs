using ExoRecipeADO.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoRecipeADO.Query
{
    internal class RecetteQuery : Query
    {
        public static new void Add()
        {
            int rowAffected = 0;

            Console.WriteLine("Entrez Nom de la Recette:");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le temps de prep de la Recette:");
            int tempsPrep = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le temps de cuisson de la Recette:");
            int tempsCuisson = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez Difficulte de la Recette:");
            string difficulte = Console.ReadLine();
            Console.WriteLine("Entrez l'id de categorie de la Recette:");
            int id_categorie = Int32.Parse(Console.ReadLine());

            string query = "INSERT INTO Recette(Nom, TempsPrep, TempsCuisson, Difficulte, id_categorie) VALUES (@nom,@tempsPrep,@tempsCuisson,@difficulte,@id_categorie);";

            try
            {

                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@tempsPrep", tempsPrep);
                cmd.Parameters.AddWithValue("@tempsCuisson", tempsCuisson);
                cmd.Parameters.AddWithValue("@difficulte", difficulte);
                cmd.Parameters.AddWithValue("@id_categorie", id_categorie);

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
            string query = "SELECT * FROM Recette;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recette recette = new Recette(
                            reader.GetInt32("ID"),
                            reader.GetString("Nom"),
                            reader.GetInt32("TempsPrep"),
                            reader.GetInt32("TempsCuisson"),
                            reader.GetString("Difficulte"),
                            reader.GetInt32("id_categorie")
                            );

                        Console.WriteLine(recette);
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
            string query = "SELECT * FROM Recette WHERE Id = @id;";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Recette recette = new Recette(
                            reader.GetInt32("ID"),
                            reader.GetString("Nom"),
                            reader.GetInt32("TempsPrep"),
                            reader.GetInt32("TempsCuisson"),
                            reader.GetString("Difficulte"),
                            reader.GetInt32("id_categorie")
                            );

                    Console.WriteLine(recette);
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
            string query = "UPDATE Recette SET Nom = @nom, TempsPrep = @tempsPrep, TempsCuisson = @tempsCuisson, Difficulte = @difficulte, id_categorie = @idCat WHERE Id = @id;";

            Console.WriteLine("Entrez le nouveau Nom de la Recette:");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez  le nouveau temps de prep de la Recette:");
            int tempsPrep = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez  le nouveau temps de cuisson de la Recette:");
            int tempsCuisson = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez  le nouveau Difficulte de la Recette:");
            string difficulte = Console.ReadLine();
            Console.WriteLine("Entrez  le nouveau id de cat de la Recette:");
            int id_categorie = Int32.Parse(Console.ReadLine());

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
                cmd.Parameters.AddWithValue("@tempsPrep", tempsPrep);
                cmd.Parameters.AddWithValue("@tempsCuisson", tempsCuisson);
                cmd.Parameters.AddWithValue("@difficulte", difficulte);
                cmd.Parameters.AddWithValue("@idCat", id_categorie);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nRecette modifié avec succes");
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
            string query = "DELETE FROM Recette WHERE ID = @id;";

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
                    Console.WriteLine("Succes query\nRecette supprimé avec succes");
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

       
        public static void AddIngredients(int id_recette,int id_ingredient)
        {
            string query = "INSERT INTO IngredientsRecette(id_recette, id_ingredient) VALUES(@id_recette, @id_ingredient);";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_recette", id_recette);
                cmd.Parameters.AddWithValue("@id_ingredient", id_ingredient);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nJointure cree avec succes");
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

        public static void GetAllIngredients(int id)
        {

        }
        public static void AddEtape(int id_recette, int id_etape)
        {
            string query = "INSERT INTO EtapesRecette(id_recette, id_etape) VALUES(@id_recette, @id_etape);";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_recette", id_recette);
                cmd.Parameters.AddWithValue("@id_etape", id_etape);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nJointure cree avec succes");
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

        public static void GetAllEtape(int id)
        {

        }
        public static void AddCommentaire(int id_recette, int id_commentaire)
        {
            string query = "INSERT INTO CommentaireRecette(id_recette, id_commentaire) VALUES(@id_recette, @id_commentaire);";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_recette", id_recette);
                cmd.Parameters.AddWithValue("@id_commentaire", id_commentaire);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nJointure cree avec succes");
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

        public static void GetAllCommentaire(int id)
        {

        }

        private static bool CheckIfExist(int id)
        {
            int count = 0;
            try
            {
                string queryCheck = "SELECT COUNT(*) FROM Recette WHERE ID = @id;";
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

