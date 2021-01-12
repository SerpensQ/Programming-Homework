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

        static Random r = new Random();

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {

            var OriginalHue = Convertors.GetPixelHue(originalPixel);
            var OriginalSaturation = Convertors.GetPixelSaturation(originalPixel);
            var OriginalLightness = Convertors.GetPixelLightness(originalPixel);
            
           
            var NewLightness=(parameters as MonochromeNoiseParameters).NoiseIntencity* r.NextDouble()+(1- (parameters as MonochromeNoiseParameters).NoiseIntencity) *OriginalLightness;
        
            return Convertors.HSLtoPixel(OriginalHue, OriginalSaturation, NewLightness);
        }
    }
}
