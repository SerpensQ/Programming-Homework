using System;
using System.Windows.Forms;
using System.Drawing;

namespace PhotoEnhancer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Brighter | Darker",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Gray scale",
                (pixel, parameters) =>
                {
                    var chanel = 0.3 * pixel.R +
                                0.6 * pixel.G +
                                0.1 * pixel.B;

                    return new Pixel(chanel, chanel, chanel);
                }
                ));

             mainForm.AddFilter(new PixelFilter<EmptyParameters> ("RGB -> HSL -> RGB", (pixel, parameters)=>
            {
                var OriginalHue = Convertors.GetPixelHue(pixel);
                var OriginalSaturation = Convertors.GetPixelSaturation(pixel);
                var OriginalLightness = Convertors.GetPixelLightness(pixel);
               
                return Convertors.HSLtoPixel(OriginalHue, OriginalSaturation, OriginalLightness);
            }
            ));

            mainForm.AddFilter(new TransformFilter(
                "Horizontal Mirror",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));


            mainForm.AddFilter(new TransformFilter(
                "Rotate 90 degrees left",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));


            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Free rotation", new RotateTransformer()));


            mainForm.AddFilter(new PixelFilter<MonochromeNoiseParameters>(
                "Monochromatic Noise",
                (pixel, parameters) =>
                {
                var OriginalHue = Convertors.GetPixelHue(pixel);
                var OriginalSaturation = Convertors.GetPixelSaturation(pixel);
                var OriginalLightness = Convertors.GetPixelLightness(pixel);

                  
                Random r = new Random();
                var NewLightness = parameters.NoiseIntencity * r.NextDouble() +(1-parameters.NoiseIntencity)* OriginalLightness;

                return Convertors.HSLtoPixel(OriginalHue, OriginalSaturation, NewLightness);
                }
                ));


            mainForm.AddFilter(new TransformFilter("Side Diagonal Mirror", size => new Size(size.Height, size.Width),
                   (point, size) => new Point(size.Width - point.Y - 1, size.Height - 1 - point.X)));

            mainForm.AddFilter(new TransformFilter<VerticalBevelTransformParameters>("Vertical Bevel", new VerticalBevelTransformer()));

            Application.Run(mainForm);
        }
    }
}
