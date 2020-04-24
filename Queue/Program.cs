using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество знаков числа");
            var k = int.Parse(Console.ReadLine());

            var minNumber = (int)Math.Pow(10, k - 1);
            var maxNumber = (int)Math.Pow(10, k);

            Console.WriteLine("Введите количество чисел");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");

            var numbers = new Queue<int>[10];

            for (var i = 0; i < numbers.Length; i++)
                numbers[i] = new Queue<int>();

            var rnd = new Random();

            for(var i=0; i<n; i++)
            {
                int m = rnd.Next(minNumber, maxNumber);
                Console.Write($"{m} ");
                numbers[m % 10].Enqueue(m);
            }

            Console.WriteLine("\n");

            for(var i=0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Числа, заканчивающиеся на {i}");
                while (numbers[i].Count > 0)
                    Console.Write($"{numbers[i].Dequeue()} ");
            }

            Console.ReadKey();
        }
    }
}
