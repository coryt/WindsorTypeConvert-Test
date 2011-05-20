using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Castle.Core.Configuration;
using Castle.MicroKernel.SubSystems.Conversion;

namespace WindsorTypeConvertTest.Routing.Config
{
    public class RouteValueTranslationTypeConverter : AbstractTypeConverter
    {
        public override bool CanHandleType(Type type)
        {
            return type == typeof(ITranslatableRouteValue);
        }

        public override bool CanHandleType(Type type, IConfiguration configuration)
        {
            return type == typeof(ITranslatableRouteValue);
        }

        public override object PerformConversion(string value, Type targetType)
        {
            throw new NotImplementedException();
        }

        public override object PerformConversion(IConfiguration configuration, Type targetType)
        {
            string areaName = Context.Composition.PerformConversion(configuration.Children.SingleOrDefault(c => c.Name == "areaName"), typeof(string)) as string;
            string routeValue = Context.Composition.PerformConversion(configuration.Children.SingleOrDefault(c => c.Name == "routeValue"), typeof(string)) as string;
            var translationTable = Context.Composition.PerformConversion(configuration.Children.SingleOrDefault(c => c.Name == "translationTable"), typeof(IDictionary)) as IDictionary;

            Dictionary<CultureInfo, string> cultureTranslationTable = translationTable.Keys.Cast<string>().ToDictionary(key => CultureInfo.GetCultureInfo(key), key => translationTable[key] as string);

            return new TranslatableRouteValue(areaName, routeValue, cultureTranslationTable);
        }
    }
}