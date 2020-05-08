using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Table
    {
        public int RowNumber;
        public double Start;
        public double Step;

        public void Print(string name, UnaryOperation f)
        {
            var horizontalLine = new string('-', 17);
            // шапка таблицы
            Console.WriteLine(horizontalLine);
            Console.WriteLine("|   x   | " + name);
            Console.WriteLine(horizontalLine);

            //печать значений
            var x = Start;
            for(var i=0; i<RowNumber; i++)
            {
                Console.WriteLine($"| {x,5:F2} | {f(x):F3}");
                x += Step;
            }

            //нижняя линейка
            Console.WriteLine(horizontalLine);
            Console.WriteLine();
        }  
        
    }
    class Calculator
    {
        public double Cube(double x)
        {
            return x * x * x;
        }
    }
}
