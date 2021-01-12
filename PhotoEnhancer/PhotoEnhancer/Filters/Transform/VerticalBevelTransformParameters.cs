using System;

namespace PhotoEnhancer
{
    public class VerticalBevelTransformParameters : IParameters
    {
        [ParameterInfo(Name = "Vertical bevel angle in degrees", MinValue = -85, MaxValue = 85, DefailtValue = 0, Increment = 5)]
        public double VerticalBevelAngleInDegrees { get; set; }
    }
}
