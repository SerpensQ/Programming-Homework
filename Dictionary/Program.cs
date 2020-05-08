using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        //Обычный метод для вывода результат
        static void OutputResult(Dictionary<int, double> data)
        {
            foreach (var element in data)
                Console.WriteLine(element.Key + "  " + element.Value);
        }

        //Сначала подсчитываем общую сумму всех значений.
        //Создаем новый словарь, который будет содержать значение и их частоты

        static void GetResult(Dictionary<int, int> data)
        {
            var sum = 0;
            foreach (var element in data)
                sum += element.Value;
            var result = new Dictionary<int, double>();
            foreach (var element in data)
            //Подсчитываем частоты и добавляем в словарь
                result.Add(element.Key, element.Value * 1.0 / sum);
            OutputResult(result);
        }

        //Нам нужно выводить значение в порядке возрастания. Отсортируем список с помощью метода Sort.
        //Создадим словарь, в котором будем хранить значение и сколько раз оно встретилось в списке.
        //Key - значение; Value - количество повторений. 
        //После того, как мы сформировали словарь, найдем относительные частоты с помощью метода GetResult

        static void GetMathDictionary(List<int> list)
        {
            list.Sort();
            var result = new Dictionary<int, int>();
            foreach(var element in list)
            {
                if (!result.ContainsKey(element))
                    result.Add(element, 1);
                else
                    result[element]++;
            }
            GetResult(result);
        }

        //Начинаем анализ строки. В этом методе мы создаем список, в котором мы будем хранить все значения.
        //Парсим строку по пробелу с помощью метода Split, полученные значения добавляем в список и продолжаем анализ в методе GetMathDicionary
        static void MathStatistics(string line)
        {
            List<int> data = new List<int>();
            foreach (var element in line.Split(' '))
                data.Add(int.Parse(element));
            GetMathDictionary(data);
        }

        static void Main()
        {
            //Считываем данные из файла
            var path = @"sample.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                //Считываем строку из файла, потом анализируем её в методе MathStatisstics
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    MathStatistics(line);
                    //Так мы можем контролировать вывод данных. Будем выводить их только когда нужно.
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
