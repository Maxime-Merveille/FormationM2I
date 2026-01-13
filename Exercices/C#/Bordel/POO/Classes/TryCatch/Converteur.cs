using System;
using System.Collections.Generic;
using System.Text;

namespace POO.Classes.TryCatch
{
    internal class Converteur
    {

        public static void Init()
        {
            int nombre;
            bool conversionReussie = false;

            while (!conversionReussie)
            {
                Console.Write("Veuillez saisir un entier : ");
                string saisie = Console.ReadLine();

                try
                {
                    nombre = int.Parse(saisie);
                    conversionReussie = true;
                    Console.WriteLine("Conversion réussie ! L'entier saisi est : " + nombre);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : la valeur saisie n'est pas un entier valide.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erreur : le nombre saisi est trop grand ou trop petit.");
                }
            }
        }
    }
}
