using System.Collections.Generic;
using System.Diagnostics;

namespace WindsorTypeConvertTest.Routing
{
    public class RouteTranslationBuilder : IRouteTranslationBuilder
    {
        public RouteTranslationBuilder(IEnumerable<ITranslatableRouteValue> controllerTranslations)
        {
            Debug.Assert(controllerTranslations != null);
        }
    }
}