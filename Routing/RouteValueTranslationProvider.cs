using System.Collections.Generic;

namespace WindsorTypeConvertTest.Routing
{
    public class RouteValueTranslationProvider : IRouteValueTranslationProvider
    {
        public IList<ITranslatableRouteValue> Translations { get; private set; }

        public RouteValueTranslationProvider(IList<ITranslatableRouteValue> translations)
        {
            Translations = translations;
        }
    }
}
