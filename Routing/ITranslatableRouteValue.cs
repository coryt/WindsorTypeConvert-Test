using System.Collections.Generic;
using System.Globalization;

namespace WindsorTypeConvertTest.Routing
{
    public interface ITranslatableRouteValue
    {
        string AreaName { get; set; }
        string RouteValue { get; set; }
        Dictionary<CultureInfo, string> TranslationTable { get; set; }
    }
}