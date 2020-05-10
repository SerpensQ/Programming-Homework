using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DictionaryTask
{


    class Program
    {
     
        static void Main()
        {

            var path = @"sample.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    LineAnalysis(line);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }

        static void GetResult(Dictionary<int, int> info)
        {
            var sum = 0;
            foreach (var elem in info)
                sum += elem.Value;
            var result = new Dictionary<int, double>();
            foreach (var elem in info)
                result.Add(elem.Key, elem.Value * 1.0 / sum);
            FinalResult(result);
        }
        static void GetDictionary(List<int> list)
        {
            list.Sort();
            var result = new Dictionary<int, int>();
            foreach (var element in list)
            {
                if (!result.ContainsKey(element))
                    result.Add(element, 1);
                else
                    result[element]++;
            }
            GetResult(result);
        }

        static void LineAnalysis(string line)
        {
            List<int> data = new List<int>();
            foreach (var element in line.Split(' '))
                data.Add(int.Parse(element));
            GetDictionary(data);
        }

        static void FinalResult(Dictionary<int, double> info)
        {
            foreach (var elem in info)
                Console.WriteLine(elem.Key + "  " + elem.Value);
        }

    }
}


