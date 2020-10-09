using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
   public class GrayScaleFilter : PixelFilter
    {

        public GrayScaleFilter():base(new EmptyParameters()) { }
        
        public override string ToString()
        {
            return "Gray scale";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {
            var channel = 0.3 * originalPixel.R + 0.6 * originalPixel.G + 0.1 * originalPixel.B;
            return new Pixel(channel, channel, channel);
        }
    }
}
