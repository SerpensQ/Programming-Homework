using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class VerticalBevelTransformer: ITransformer<VerticalBevelTransformParameters>
     {
        public Size ResultSize { get; private set; }

        Size originalSize;
        double angleInRadians;

        public void Initialize(Size size, VerticalBevelTransformParameters parameters)
        {
            originalSize = size;
            angleInRadians = parameters.VerticalBevelAngleInDegrees * Math.PI / 180;
            

            ResultSize = new Size(
                (int)(size.Width), (int)(size.Height + (size.Width* Math.Abs(Math.Tan(angleInRadians)))));
        }

        public Point? MapPoint(Point point)
        {
            point = new Point(point.X, point.Y);

            var newX = point.X;
            int newY;

            if(angleInRadians>=0)
                newY= (int)(point.Y - (originalSize.Width - point.X - 1) * Math.Tan(angleInRadians));
            else 
                 newY= (int)(point.Y + point.X * Math.Tan(angleInRadians));


            if (newX < 0 || newX >= originalSize.Width || newY < 0 || newY >= originalSize.Height)
                return null;

            return new Point(newX, newY);

        }
    }
}
