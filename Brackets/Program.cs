using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {

        static Dictionary<char, char> dict;
        static void Main()
        {
            Console.WriteLine("Ведите пары скобок (открывающая, закрывающая) в одной строке");
            var brackets = Console.ReadLine();
            if (brackets.Length % 2 != 0)
            {
                Console.WriteLine("Скобки должны вводиться парами");
                Console.ReadKey();
                return;
            }
            for (var i = 0; i < brackets.Length; i += 2)
                dict[brackets[i + 1]] = brackets[i];

            while (true)
            {
                Console.WriteLine("Введите выражение со скобками(Enter-выход)");
                var line = Console.ReadLine();
                     if (line == "")
                    break;


                if (CheckBrackets(line))
                    Console.WriteLine("Скобки расставлены верно\n");
                else
                    Console.WriteLine("Скобки расставлены не верно\n");
                
            }
        }

        static bool CheckBrackets(string expression)
        {
            var stack = new Stack<char>();

            for(var i=0; i<expression.Length; i++)
            {
                var ch = expression[i];

                if (dict.ContainsValue(ch))
                    stack.Push(ch);


                else if (dict.ContainsKey(ch))
                    if (stack.Count == 0 || stack.Pop() != dict[ch])
                        return false;                
            }

            return stack.Count == 0;
        }
    }
}
