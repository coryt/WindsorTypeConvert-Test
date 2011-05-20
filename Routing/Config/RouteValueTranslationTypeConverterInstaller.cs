using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel.SubSystems.Conversion;
using Castle.Windsor;

namespace WindsorTypeConvertTest.Routing.Config
{
    public class RouteValueTranslationTypeConverterInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var manager = (IConversionManager)container.Kernel.GetSubSystem(SubSystemConstants.ConversionManagerKey);
            manager.Add(new RouteValueTranslationTypeConverter());
        }
    }
}