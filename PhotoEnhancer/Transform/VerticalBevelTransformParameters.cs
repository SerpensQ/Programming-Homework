using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class VerticalBevelTransformParameters : IParameters
    {
        public double VerticalBevelAngleInDegrees { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name="Vertical bevel angle in degrees",
                    MinValue=-85,
                    MaxValue=85,
                    DefaultValue=0,
                    Increment=5
                }
            };
        }

        public void SetValues(double[] values)
        {
            VerticalBevelAngleInDegrees = values[0];
        }
    }


}
