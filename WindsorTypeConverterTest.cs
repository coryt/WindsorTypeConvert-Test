using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindsorTypeConvertTest.Routing;
using WindsorTypeConvertTest.Routing.Config;

namespace WindsorTypeConvertTest
{
    [TestClass]
    public class WindsorTypeConverterTest
    {
        private IRouteTranslationBuilder builder;

        [TestInitialize()]
        public void TestSetup()
        {
            IWindsorContainer container = new WindsorContainer();

            container
                .Install(new RouteValueTranslationTypeConverterInstaller())
                .Install(Configuration.FromXmlFile("RoutingTranslations.config"))
                .Register(
                    Component
                        .For<IRouteTranslationBuilder>()
                        .ImplementedBy<RouteTranslationBuilder>()
                        .Named("routeTranslationBuilder")
                );

            builder = container.Resolve<IRouteTranslationBuilder>();
        }

        [TestMethod]
        public void BootstrapperConfiguresRouteTranslations_BuilderShouldBePopulated()
        {
            Assert.IsNotNull(builder);
        }
    }
}
