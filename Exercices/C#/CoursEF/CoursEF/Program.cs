using CoursEF.Data;
using CoursEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursEF
{
    internal class Program
    {
        public static void AddStudent()
        {
            Student student = new Student("Maxime", 422, DateTime.Now);

            using(var db = new AppDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
           
        }

        public static void UpdateStudent()
        {

            using (var db = new AppDbContext())
            {
                Student student = db.Students.FirstOrDefault();
                student.Name = "Merveille Maxime";
                student.ClassNumber = 666;
                db.Students.Update(student);
                db.SaveChanges();
            }

        }

        public static Student GetStudent()
        {
            Student stu;
            using (var db = new AppDbContext())
            {
                stu = db.Students.First();
            }
            return stu;
        }

        public static void DeleteStudent()
        {
            Student student = GetStudent();
            using (var db = new AppDbContext())
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public static void UpdateStudentById(int id, string nom, int numClasse)
        {

            using (var db = new AppDbContext())
            {
                Student student = db.Students.Find(id);

                if (student == null)
                {
                    Console.WriteLine("Student not found");
                    return;
                }

                student.Name = nom;
                student.ClassNumber = numClasse;
                
                db.Students.Update(student);
                db.SaveChanges();
            }

        }

        public static Student GetStudentById(int id)
        {
            Student stu;
            using (var db = new AppDbContext())
            {
                stu = db.Students.Find(id);
            }
            return stu;
        }

        public static void DeleteStudentById(int id)
        {
           
            using (var db = new AppDbContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    Console.WriteLine("Student not found");
                    return;
                }

                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public static List<Student> GetAllStudent()
        {
            using (var db = new AppDbContext())
            {
                return db.Students.ToList();
            }
        }

        public static List<Student> GetStudentByName(string name)
        {
            using (var db = new AppDbContext())
            {
                return db.Students.Where(student => student.Name.Contains(name)).ToList();
            }
        }

        public static List<Student> GetStudentByClasse(int classe)
        {
            using (var db = new AppDbContext())
            {
                return db.Students.Where(student => student.ClassNumber.Equals(classe)).ToList();
            }
        }

        static void Main(string[] args)
        {
            //AddStudent();
            //Console.WriteLine(GetStudent());
            //UpdateStudent();
            //Console.WriteLine(GetStudent());
            //DeleteStudent();

            //Console.WriteLine(GetStudentById(8));
            //UpdateStudentById(10, "Eugenie LaGenie", 1);
            //UpdateStudentById(11, "GigaChad Julien", 30);
            //Console.WriteLine(GetStudentById(8));
            //DeleteStudentById(8);

            Console.WriteLine("\n==== Print de tous les Student ====\n");
            foreach (var student in GetAllStudent())
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n==== Print de tous les Student de la classe 1 ====\n");
            foreach (var student in GetStudentByClasse(1))
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n==== Print de tous les Student qui s'appellent GigaChad ====\n");
            foreach (var student in GetStudentByName("GigaChad"))
            {
                Console.WriteLine(student);
            }
        }

    }
}
