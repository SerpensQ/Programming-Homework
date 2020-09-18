using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class Pixel
    {
        //яркость канала должна быть числом от 0 до 1
        private double r;
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = CheckValue(value);
            }
        }

        private double g;
        public double G
        {
            get{return g;}
            set { g = CheckValue(value);}
        }

        private double b;
        public double B
        {
            get {return b;}
            set{ b = CheckValue(value);}
        }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new Exception($"Неверное значение канала {val}. Оно должно быть от 0 до 1.");
            return val;
        }
    }
}
