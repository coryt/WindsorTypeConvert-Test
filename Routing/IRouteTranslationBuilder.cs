using System.Collections.Generic;

namespace WindsorTypeConvertTest.Routing
{

    public interface IRouteTranslationBuilder
    {
        Dictionary<string, IEnumerable<ITranslatableRouteValue>> RouteValueTranslations { get; }
        RouteValueTranslationProvider ControllerTranslationProvider { get; }
        RouteValueTranslationProvider ActionTranslationProvider { get; }
    }
}