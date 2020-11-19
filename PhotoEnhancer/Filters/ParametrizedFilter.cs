using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{

    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters: IParameters, new()
    {
        //IParameters parameters;

        //public ParametrizedFilter(IParameters p)
        //{
        //    parameters = p;
        //}
        public ParameterInfo[] GetParemeterInfo()
        {
            return new TParameters().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParameters();
            parameters.SetValues(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters parameters);
    }
}
