using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Genealogy
{
    class Program
    {
        static Dictionary<string, string> tree = new Dictionary<string, string>();
        static void Main()
        {
            InitializeTree();

            if (tree.Count == 0)
                return;

            while (true)
            {
                Console.WriteLine("Choose your option: ");
                Console.WriteLine("1- Progenitor");
                Console.WriteLine("2- Closest common ancestor");
                Console.WriteLine("0- Exit program");

                int result=0;

                if (!int.TryParse(Console.ReadLine(), out result) || result> 2|| result<0)
                {
                    Console.WriteLine("\n Choose the number of listed options");
                    continue;
                }
                
                switch (result)
                {
                    case 1:
                        PrintProgenitor();
                        break;
                    case 2:
                        Console.WriteLine("Type the name of the first person");
                        var first = Console.ReadLine();
                        if (!IsCorrectPerson(first))
                            continue;

                        Console.WriteLine("Type the name of the second person");
                        var second = Console.ReadLine();
                        if (!IsCorrectPerson(second))
                            continue;

                        CheckRelative(first, second);
                        break;

                    default:
                        return;
                }
               
            }

        }

        static void InitializeTree()
        {
            string filename;

            while (true)
            {
                Console.WriteLine("Type the name of the file");
                filename = Console.ReadLine();

                if (filename == "")
                    return;

                if (File.Exists(filename))
                    break;
                else
                    Console.WriteLine("This file doen't exist\n");
            }

            using (var file= new StreamReader(filename, Encoding.Default))
            {
                string line;

                while (!file.EndOfStream)
                {
                    line = file.ReadLine();
                    string[] record = line.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    tree[record[1]] = record[0];
                }
            }
        }

        static void PrintProgenitor()
        {
            foreach(var person in tree.Values)
                if (!tree.ContainsKey(person))
                {
                    Console.WriteLine($"The progenitor - {person}. \n");
                    break;
                }
        }

        static void CheckRelative(string a, string b)
        {
            var ancestorA = GetAncestors(a);
            var ancestorB = GetAncestors(b);

            if (ancestorB.Contains(a))
                Console.WriteLine($"{a} - ancestor, {b} - descendant");
            else if(ancestorA.Contains(b))
                Console.WriteLine($"{b} - ancestor, {a} - descendant");
            else
            { 

                foreach(var person in ancestorA)
                    if (ancestorB.Contains(person))
                    {
                        Console.WriteLine($"Closest common ancestor- {person}\n");
                        break;
                    }
            }
        }

        static bool IsCorrectPerson(string person)
        {
            if (!tree.ContainsKey(person) || tree.ContainsValue(person))
            {
                Console.WriteLine($"{person} doesn't exist in the tree");
                return false;
            }
            else
                return true;
        }

        static List<string> GetAncestors(string person)
        {
            var result = new List<string>();

            
                while (tree.ContainsKey(person))
                {
                person = tree[person];
                result.Add(person);
                }
            return result;
        }
    }
}
