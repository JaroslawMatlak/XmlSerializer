using SerializerApi.Models;
using System.Xml;

namespace SerializerApi.XmlConverter
{
    public interface IXmlConverter
    {
        XmlDocument RequestModelToXml(RequestModel requestModel);
    }
}
