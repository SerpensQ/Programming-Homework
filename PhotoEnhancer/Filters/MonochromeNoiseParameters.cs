using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MonochromeNoiseParameters: IParameters
    {
        public double NoiseIntencity { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name="NoiseIntencity",
                    MinValue=0,
                    MaxValue=1,
                    DefaultValue=0,
                    Increment=0.01
                }
            };
        }

        public void SetValues(double[] values)
        {
            NoiseIntencity = values[0];
        }
    }
}
