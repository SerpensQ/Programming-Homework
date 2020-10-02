using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
   public class GrayScaleFilter : PixelFilter
    {
        //public Photo Process(Photo original, double[] parameters)
        //{
        //    var newPhoto = new Photo(original.Width, original.Height);

        //    for (int x = 0; x < original.Width; x++)
        //        for (int y = 0; y < original.Height; y++)
        //        {
        //            //var channel = 0.3 * original[x, y].R + 0.6 * original[x, y].G + 0.1 * original[x, y].B;
        //            //newPhoto[x, y] = new Pixel(channel, channel, channel);
        //            newPhoto[x, y] = ProcessPixel(original[x, y], parameters);
        //        }

        //    return newPhoto;
        //}
        public override string ToString()
        {
            return "Gray scale";
        }

        public override ParameterInfo[] GetParemeterInfo()
        {
            return new ParameterInfo[0];
        }

        public override Pixel ProcessPixel(Pixel originalPixel, double[] parameters)
        {
            var channel = 0.3 * originalPixel.R + 0.6 * originalPixel.G + 0.1 * originalPixel.B;
            return new Pixel(channel, channel, channel);
        }
    }
}
