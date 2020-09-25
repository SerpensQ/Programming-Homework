using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public struct Pixel
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

        public Pixel(double red, double green, double blue): this() 
        {
            R = red;
            G = green;
            B = blue;
        }
        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new Exception($"Неверное значение канала {val}. Оно должно быть от 0 до 1.");
            return val;
        }

        public static double Trim(double channel)
        {
            if (channel > 1)
                return 1;
            else if (channel < 0)
                return 0;

            return channel;
        }

        public static Pixel operator * (Pixel p, double k)
        {
            return new Pixel(Trim(p.R*k), Trim(p.G*k), Trim(p.B*k));
        }

        public static Pixel operator *(double k, Pixel p)
        {
            return p * k;
        }
    }
}
