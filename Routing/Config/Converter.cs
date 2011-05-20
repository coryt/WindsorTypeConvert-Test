using System;
using System.Linq;
using Castle.Core.Configuration;
using Castle.MicroKernel.SubSystems.Conversion;

namespace WindsorTypeConvertTest.Routing.Config
{
    public class Converter
    {
        private readonly ConfigurationCollection configurationCollection;
        private readonly ITypeConverterContext context;

        public Converter(ConfigurationCollection configurationCollection, ITypeConverterContext context)
        {
            this.configurationCollection = configurationCollection;
            this.context = context;
        }

        public T Get<T>(string parameter)
        {
            var configuration = configurationCollection.SingleOrDefault(c => c.Name == parameter);
            if (configuration == null)
            {
                throw new ApplicationException(string.Format(
                    "In the castle configuration, type '{0}' expects parameter '{1}' that was missing.",
                    typeof(T).Name, parameter));
            }
            return (T)context.Composition.PerformConversion(configuration, typeof(T));
        }
    }
}