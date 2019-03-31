using SerializerApi.Models;
using System.Xml;

namespace SerializerApi.XmlConverting
{
    public interface IXmlConverter
    {
        XmlDocument RequestModelToXml(RequestModel requestModel);
    }
}
