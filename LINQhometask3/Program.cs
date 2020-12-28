using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQhometask3
{
    
    class Program
    {
        public static void Main(string[] args)
        {

        }

        static string GetCapitalLetterArray(string[] array)
        {
            return array
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.ToUpper())
                .OrderBy(x => x).ToString();

        }

        static void PrintTotalDurationHours(int year, int month, int hours, List<Record> db)
        {
            var lines = db

                .Select(e => new
                {
                    hours = int.Parse(e.ToString()),
                    month = int.Parse(e.ToString()),
                    year = int.Parse(e.ToString())
                })
                .GroupBy(e => e.month + e.year)
                .OrderByDescending(e => e.Sum(c => c.hours))
                .ThenBy(e => e.Key)
                .Select(e => (e.Sum(c => c.hours), e.Key));

            if (lines.Count() > 0)
            {
                foreach (var line in lines)
                    Console.WriteLine($"Общая продолжительность занятий составила: {line.Item1} ч. в {line.Key} г.");

            }
            else Console.WriteLine($"За {year} год нет данных.");


        }
    }
}
