using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter
    {
        public LighteningFilter() : base(new LighteningParameters()) { }

        
        public override string ToString()
        {
            return "Brighter | Darker";
        }

        public override Pixel ProcessPixel (Pixel originalPixel, IParameters parameters)
        {
            
           return originalPixel * (parameters as LighteningParameters).Coefficient;
        }
    }
}
