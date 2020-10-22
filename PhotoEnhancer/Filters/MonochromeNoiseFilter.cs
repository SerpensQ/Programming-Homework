using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class MonochromeNoiseFilter : PixelFilter
    {
        public MonochromeNoiseFilter() : base(new MonochromeNoiseParameters()) { }


        public override string ToString()
        {
            return "Monochromatic Noise";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {

            var OriginalHue = Convertors.GetPixelHue(originalPixel);
            var OriginalSaturation = Convertors.GetPixelSaturation(originalPixel);
            var OriginalLightness = Convertors.GetPixelLightness(originalPixel);
            
            Random r = new Random();
            var NewLightness=(parameters as MonochromeNoiseParameters).NoiseIntencity* r.Next(0,2)*OriginalLightness;
        
            return Convertors.HSLtoPixel(OriginalHue, OriginalSaturation, NewLightness);
        }
    }
}
