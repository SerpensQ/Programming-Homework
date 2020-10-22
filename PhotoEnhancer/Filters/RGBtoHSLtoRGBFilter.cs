using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class RGBtoHSLtoRGBFilter: PixelFilter
    {
        public RGBtoHSLtoRGBFilter() : base(new EmptyParameters()) { }
        public override string ToString()
        {
            return "RGB -> HSL -> RGB";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {
            var OriginalHue = Convertors.GetPixelHue(originalPixel);
            var OriginalSaturation = Convertors.GetPixelSaturation(originalPixel);
            var OriginalLightness = Convertors.GetPixelLightness(originalPixel);
            //maths
            //var newL=

            //все ориг кроме у меня светлоты
            return Convertors.HSLtoPixel(OriginalHue, OriginalSaturation, OriginalLightness);
        }
    }
}
