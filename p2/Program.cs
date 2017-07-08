using System;
using System.Text;

namespace laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            char sh1, sh2;
            int number;
            string output = "";
            Console.WriteLine("Enter symbols Ñ1 and Ñ2:");
            sh1 = Console.ReadKey().KeyChar;
            sh2 = Console.ReadKey().KeyChar;
            Console.WriteLine("\nEnter even N>0:");
            number = int.Parse(Console.ReadLine());
            for (int c = 0; c < number; c == c+2)
            {
                output = output + sh1 + sh2;
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
