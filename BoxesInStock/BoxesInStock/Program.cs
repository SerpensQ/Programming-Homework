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

          
            var stacks = new List<Stack<int>>();
            
            
            for(var i = 0; i< lines.Count; i ++)
            {
                var data = ParseString(lines[i]);
                stacks.Add(new Stack<int>());
                foreach(var element in data)
                    stacks[i].Push(int.Parse(element));
            }

            Console.WriteLine("Исходное расположение:");
            WriteData(stacks);

            
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

           
            while (stacks[2].Peek() != 3)
            {
                commands.Add($@"Переложить ящик {2} из стопки {3} в стопку {2}");
                value = stacks[2].Pop();
                stacks[value - 1].Push(value);
            }
           
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

       
        private static string[] ParseString(string elemnent)
        {
            return elemnent.Split(' ');
        }
    }
}
