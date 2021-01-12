using System;

namespace PhotoEnhancer
{
    public class MonochromeNoiseParameters : IParameters
    {
        [ParameterInfo(Name = "NoiseIntencity", MinValue = 0, MaxValue = 1, DefailtValue = 0, Increment = 0.01)]
        public double NoiseIntencity { get; set; }
    }
}
