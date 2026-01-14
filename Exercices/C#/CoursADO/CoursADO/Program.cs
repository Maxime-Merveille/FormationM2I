using CoursADO.Classes;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace CoursADO
{
    internal class Program
    {
        public static string connectionString = "Server=localhost;Database=demo_ado;User ID=root;Password=formation";

        public static MySqlConnection connection = new MySqlConnection(connectionString);

        private static bool CheckIfExist(int id)
        {
            int count = 0;
            try
            {
                string queryCheck = "SELECT COUNT(*) FROM Personne WHERE ID = @id;";
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

        //============== CREATE ==============

        /// <summary>
        /// Methode d'ajout d'une personne en BDD
        /// </summary>
        public static void AddPersonne()
        {
            Console.WriteLine("Entrez Nom :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez Prenom :");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez Age :");
            string age = Console.ReadLine();
            Console.WriteLine("Entrez Email :");
            string email = Console.ReadLine();

            try
            {
                connection.Open();

                string query = "INSERT INTO Personne(Nom, Prenom, Age, Email) VALUES (@nom, @prenom,@age,@email);";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nom", nom);   
                cmd.Parameters.AddWithValue("@prenom", prenom);   
                cmd.Parameters.AddWithValue("@age", age);   
                cmd.Parameters.AddWithValue("@email", email);   

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur connection BDD : " + ex.Message);
            }
            finally { connection.Close(); }

            
        }

        //============== READ ==============

        /// <summary>
        /// Recupere une personne en BDD via son ID unique
        /// </summary>
        public static void GetPersonneById() {

            try
            {
                connection.Open();

                Console.WriteLine("Entrez Id :");
                int id = Int32.Parse(Console.ReadLine());

                if (!CheckIfExist(id))
                {
                    Console.WriteLine("Cet ID n'existe pas");
                    return;
                }

                string query = "SELECT * FROM Personne WHERE ID = @id;";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Personne personne = new Personne(
                        reader.GetInt32("ID"),
                        reader.GetString("Nom"),
                        reader.GetString("Prenom"),
                        reader.GetInt32("Age"),
                        reader.GetString("Email")
                        );

                    Console.WriteLine(personne);


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

        /// <summary>
        /// Recupere toutes les personne en BDD
        /// </summary>
        public static void GetAllPersonne() {

            try
            {
                connection.Open();

                string query = "SELECT * FROM Personne;";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Personne personne = new Personne(
                            reader.GetInt32("ID"),  
                            reader.GetString("Nom"),
                            reader.GetString("Prenom"),
                            reader.GetInt32("Age"),
                            reader.GetString("Email")
                            );

                        Console.WriteLine(personne);
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

        //============== UPDATE ==============
        /// <summary>
        /// Modifie une personne en BDD via son ID
        /// </summary>
        public static void UpdatePersonne()
        {


            try
            {
                connection.Open();

                Console.WriteLine("Entrez Id :");
                int id = Int32.Parse(Console.ReadLine());

                if (!CheckIfExist(id))
                {
                    Console.WriteLine("Cet ID n'existe pas");
                    return;
                }

                Console.WriteLine("Entrez Nom :");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrez Prenom :");
                string prenom = Console.ReadLine();
                Console.WriteLine("Entrez Age :");
                string age = Console.ReadLine();
                Console.WriteLine("Entrez Email :");
                string email = Console.ReadLine();

                string query = "UPDATE Personne SET Nom = @nom, Prenom = @prenom, Age = @age, Email = @email WHERE ID = @id;";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@email", email);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nPersonne modifié avec succes");
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

        //============== DELETE ==============

        /// <summary>
        /// Supprime une personne de la BDD via son ID
        /// </summary>
        public static void DeletePersonne() {

            try
            {
                connection.Open();

                Console.WriteLine("Entrez Id :");
                int id = Int32.Parse(Console.ReadLine());

                if (!CheckIfExist(id))
                {
                    Console.WriteLine("Cet ID n'existe pas");
                    return;
                }


                string query = "DELETE FROM Personne WHERE ID = @id;";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Console.WriteLine("Succes query\nPersonne supprimé avec succes");
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

        static void Main(string[] args)
        {

            //AddPersonne();
            //GetAllPersonne();
            //GetPersonneById();
            //UpdatePersonne();
            //DeletePersonne();


        }
    }
}
