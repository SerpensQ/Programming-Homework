﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : IFilter
    {
        public ParameterInfo[] GetParemeterInfo()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name="Coefficient",
                    MinValue=0,
                    MaxValue=10,
                    DefaultValue=1,
                    Increment=0.05
                }
            };
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);
         
            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                {
                    newPhoto[x, y] = original[x, y] * parameters[0];
                }

            return newPhoto;
        }

        public override string ToString()
        {
            return "Brighter | Darker";
        }
    }
}
