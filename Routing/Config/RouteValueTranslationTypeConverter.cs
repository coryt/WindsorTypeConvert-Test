using System;
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
            var converter = new Converter(configuration.Children, Context);
            var areaName = converter.Get<string>("areaName");
            var routeValue = converter.Get<string>("routeValue");
            var translationTable = converter.Get<Dictionary<String, String>>("translationTable");

            Dictionary<CultureInfo, string> cultureTranslationTable =
                translationTable.ToDictionary(c => CultureInfo.GetCultureInfo(c.Key), t => t.Value);

            return new TranslatableRouteValue(areaName, routeValue, cultureTranslationTable);
        }
    }
}