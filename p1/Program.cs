using System;

namespace Sem2Lab4Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch1, ch2;
            int n;
            string output = "";
            Console.WriteLine("������� ������� �1 � �2:");
            ch1 = Console.ReadKey().KeyChar;
            ch2 = Console.ReadKey().KeyChar;
            Console.WriteLine("\n������� ������ N>0:");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i += 2)
            {
                output = output + ch1 + ch2;
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
