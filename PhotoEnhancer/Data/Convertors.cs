using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoEnhancer.Data
{
    public static class Convertors
    {
        public static Photo BitmapToPhoto(Bitmap bmp)
        {
            var result = new Photo(bmp.Width, bmp.Height);
            for (var x = 0; x < bmp.Width; x++) 
            for (var y = 0; y < bmp.Height; y++)
                {
                    var pixel = bmp.GetPixel(x, y);
                    result[x, y].R = (double)pixel.R / 255;
                    result[x, y].G = (double)pixel.G / 255;
                    result[x, y].B = (double)pixel.B / 255;
                }

            return result;
        }

        public static Bitmap PhotoToBitmap(Photo photo)
        {
            var result = new Bitmap(photo.Width, photo.Height);
            for (var x = 0; x < photo.Width; x++)
                for (var y = 0; y < photo.Height; y++)
                {
                    result.SetPixel(x,y,Color)

                }
            return result;
        }
    }
}
