using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SerializerApi.FileSaver;
using SerializerApi.JsonConverter;
using SerializerApi.ModelContext;
using SerializerApi.XmlConverter;
using System.Web.Http;

namespace SerializerApi.DependencyInjection
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestylePerThread());

            container.Register(
                Component.For<IJsonConverter>().ImplementedBy<JsonConverter.JsonConverter>());
            container.Register(
                Component.For<IXmlConverter>().ImplementedBy<XmlConverter.XmlConverter>());
            container.Register(
                Component.For<ISerializerDataContext>().ImplementedBy<XmlSerializerDatabase>());
            container.Register(
                 Component.For<IRequestModelXmlFileSaver>().ImplementedBy<RequestModelXmlFileSaver>());
        }
    }
}