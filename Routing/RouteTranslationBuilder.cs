using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace WindsorTypeConvertTest.Routing
{
    public class RouteTranslationBuilder : IRouteTranslationBuilder
    {
        public RouteValueTranslationProvider ControllerTranslationProvider { get; private set; }
        public RouteValueTranslationProvider ActionTranslationProvider { get; private set; }
        public Dictionary<string, IEnumerable<ITranslatableRouteValue>> RouteValueTranslations { get; private set; }
        public List<CultureInfo> SupportedCultures { get; private set; }

        public RouteTranslationBuilder(IEnumerable<ITranslatableRouteValue> controllerTranslations, IEnumerable<ITranslatableRouteValue> actionTranslations)
        {
            Debug.Assert(controllerTranslations != null);
            Debug.Assert(actionTranslations != null);
            RouteValueTranslations = new Dictionary<string, IEnumerable<ITranslatableRouteValue>> { { "Controller", controllerTranslations }, { "Action", actionTranslations } };
            ControllerTranslationProvider = new RouteValueTranslationProvider(new List<ITranslatableRouteValue>(controllerTranslations));
            ActionTranslationProvider = new RouteValueTranslationProvider(new List<ITranslatableRouteValue>(actionTranslations));
        }
    }
}