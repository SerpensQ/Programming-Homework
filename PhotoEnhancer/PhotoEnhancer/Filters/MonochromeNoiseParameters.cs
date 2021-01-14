using System;

namespace PhotoEnhancer
{
    public class MonochromeNoiseParameters : IParameters
    {
        [ParameterInfo(Name = "Noise Intencity", MinValue = 0, MaxValue = 1, DefailtValue = 0, Increment = 0.01)]

        
    public double NoiseIntencity { get; set; }
        public static Random r = new Random();
    }
}
