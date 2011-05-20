using System.Collections.Generic;
using System.Globalization;
using Castle.MicroKernel.SubSystems.Conversion;

namespace WindsorTypeConvertTest.Routing
{
    [Convertible]
    public class TranslatableRouteValue : ITranslatableRouteValue
    {
        public string AreaName { get; set; }
        public string RouteValue { get; set; }
        public Dictionary<CultureInfo, string> TranslationTable { get; set; }

        public TranslatableRouteValue(string areaName, string routeValue, Dictionary<CultureInfo, string> translationTable)
        {
            AreaName = areaName;
            RouteValue = routeValue;
            TranslationTable = translationTable;
        }

        public TranslatableRouteValue(string routeValue, Dictionary<CultureInfo, string> translationTable)
            : this("", routeValue, translationTable)
        {
        }
    }
}