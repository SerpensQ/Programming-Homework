using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesInStock
{
    class Program
    {
        static void Main()
        {
            var commands = new List<string>();
            var lines = new List<string>();
            // читаем данные из файла и добавляем их в наш список
            try
            {
                using (StreamReader sr = new StreamReader("boxes.txt"))
                {
                    var text = "";
                    while ((text = sr.ReadLine()) != null)
                        lines.Add(text);
                }
            }
            catch { }

            // создаем список стопок.
            var stacks = new List<Stack<int>>();
            
            // переделываем строки в массив данных, а после кладем все в Stack
            for(var i = 0; i< lines.Count; i ++)
            {
                var data = ParseString(lines[i]);
                stacks.Add(new Stack<int>());
                foreach(var element in data)
                    stacks[i].Push(int.Parse(element));
            }

            Console.WriteLine("Исходное расположение:");
            WriteData(stacks);

            // достаем все элементы из стопок и перекладываем в самую первую
            for (var i = 1; i < stacks.Count; i++)
            {
                var e = stacks[i];
                while (e.Count != 0)
                {
                    commands.Add($@"Переложить ящик {e.Peek()} из стопки {i + 1} в стопку {1}");
                    stacks[0].Push(e.Pop());
                }
            }
            var value = 0;

            //Все ящики сложены в стопку 1, остальные стопки пустые. Теперь разложим ящики с номерами 3 , 4, 5 по своим стопкам, а с
            //номерами 1 и 2 переложим в стопку 2.
            while (stacks[0].Count != 0)
            {
                value = stacks[0].Pop();
                if (value != 1)
                {
                    commands.Add($@"Переложить ящик {value} из стопки {1} в стопку {value}");
                    stacks[value - 1].Push(value);
                }
                else
                {
                    commands.Add($@"Переложить ящик {1} из стопки {1} в стопку {2}");
                    stacks[value].Push(value);
                }
            }

            //Теперь ящики с номерами 3, 4, 5 лежат в своих стопках, стопка 1 пустая. Будем перекладывать из стопки 2 ящики 
            //с номером 1— в стопку 1, а ящики с номером 2 — в стопку 3.
            while (stacks[1].Count != 0)
            {
                value = stacks[1].Pop();
                if(value != 2)
                {
                    commands.Add($@"Переложить ящик {1} из стопки {2} в стопку {1}");
                    stacks[value - 1].Push(value);
                }
                else
                {
                    commands.Add($@"Переложить ящик {2} из стопки {2} в стопку {3}");
                    stacks[value].Push(value);
                }
            }

            // Теперь ящики с номером 1 лежат в своей стопке, стопка 2 пустая, а ящики с номером 2 лежат сверху стопки 3.
            //Переложим их в свою стопку.
            while (stacks[2].Peek() != 3)
            {
                commands.Add($@"Переложить ящик {2} из стопки {3} в стопку {2}");
                value = stacks[2].Pop();
                stacks[value - 1].Push(value);
            }
            // записываем данные в файл
            try
            {
                using(StreamWriter sr = new StreamWriter(@"result.txt", false, Encoding.Default))
                {
                    foreach (var str in commands)
                    {
                        sr.WriteLine(str);
                    }
                }
            }
            catch { };

            Console.WriteLine($"Число перекладываний: {commands.Count}");
            Console.WriteLine("Конечное расположение:");
            WriteData(stacks);

            Console.ReadKey();

        }

        // Метод для правильного вывода данных в стопках 
        private static void WriteData(List<Stack<int>> stacks)
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                var str = new StringBuilder();
                foreach (var e in stacks[i])
                    str.Append(e + " ");

                Console.WriteLine($"Стопка {i + 1}: {str}");
            }
        }

        //Парсим строку по пробелу, и записываем в массив
        private static string[] ParseString(string elemnent)
        {
            return elemnent.Split(' ');
        }
    }
}
