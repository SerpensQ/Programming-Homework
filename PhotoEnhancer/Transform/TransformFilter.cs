using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
   public class TransformFilter:TransformFilter<EmptyParameters>
    {
        public TransformFilter(string name,
            Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTranformer)
            : base(name, new FreeTransformer(sizeTransformer, pointTranformer)) { }
    }
}
