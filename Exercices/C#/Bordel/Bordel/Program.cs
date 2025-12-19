using System;

namespace Bordel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Calcul calcul = new Calcul();
            Console.WriteLine(calcul.Add(5, 5));
            Console.WriteLine(calcul.Minus(5, 5));


            short i = 22;
        }
    }
}