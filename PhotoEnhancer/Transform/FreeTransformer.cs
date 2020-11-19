using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        public Size ResultSize { get; private set; }

        Func<Size, Size> sizeTransformer;
        Func<Point, Size, Point> pointTranformer;
     

        public FreeTransformer(Func<Size, Size> sizeTransformer, 
            Func<Point, Size, Point> pointTranformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTranformer = pointTranformer;
        }

        Size oldSize;

        public void Initialize(Size size, EmptyParameters parameters)
        {
            oldSize=size;
            ResultSize = sizeTransformer(size);
        }

        public Point? MapPoint(Point newPoint)
        {
            return pointTranformer(newPoint, oldSize);
        }
    }
}
