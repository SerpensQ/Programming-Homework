using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace LINQhometask3
{
    
    class Program
    {

        public static void Main(string[] args)
        {
            var linesArray = new[]
            {
                "Вы помните, Вы все, конечно, помните.",
                "Как я стоял, приблизившись к стене, взволнованно ходили вы по комнате и что-то резкое в лицо бросали мне.",
                "Сегодня я в ударе нежных чувств. Я вспомнил вашу грустную усталость. И вот теперь я сообщить вам мчусь, каков я был и что со мною сталось.",
                "Живите так, как вас ведет звезда, под кущей обновленной сени. С приветствием, вас помнящий всегда знакомый ваш, Сергей Есенин."

            };
            Console.WriteLine(string.Join(", ", GetCapitalLetterArray(linesArray)));

            var lines = File.ReadAllLines("db.txt");
            var fitnesCentre = lines
                .Select(s => s.Split())
                .Select(data => new Record
                {
                    ClientID = int.Parse(data[0]),
                    Year = int.Parse(data[1]),
                    Month = int.Parse(data[2]),
                    Duration = int.Parse(data[3])
                })
                .ToList();

            PrintTotalDuration(fitnesCentre);
            Console.ReadKey();
        }

       
        static string[] GetCapitalLetterArray(string[] array)
        {
            return array

                .SelectMany(line => line.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
              
                .Where(word => char.IsUpper(word[0]))
              
                .Distinct()
               
                .OrderBy(word => word)
             
                .ToArray();
        }

        
        static void PrintTotalDuration(List<Record> db)
        {
            var durations = db
                .GroupBy(record => (record.Year, record.Month))
                .Select(records => (
                  
                    duration: records.Sum(record => record.Duration),
                    month: records.Key.Month,
                    year: records.Key.Year))
              
                .OrderByDescending(e => e.year)
                .ThenBy(e => e.month);

            foreach (var (duration, month, year) in durations)
                Console.WriteLine($"Общая продолжительность занятий составила: {duration} ч. Месяц: {month}  Год: {year}.");
        }
       
    }
}
