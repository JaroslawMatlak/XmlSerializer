using SerializerApi.Models;
using System.Xml;

namespace SerializerApi.XmlConverter
{
    public class XmlConverter
    {
        public XmlDocument RequestModelToXml(RequestModel requestModel)
        {
            if (requestModel == null)
                return null;

            var doc = new XmlDocument();
            var request = (XmlElement)doc.AppendChild(doc.CreateElement("request"));
            request.AppendChild(doc.CreateElement("ix")).InnerText = requestModel.Index.ToString();
            var content = (XmlElement)request.AppendChild(doc.CreateElement("content"));
            if (requestModel.Name != null)
                content.AppendChild(doc.CreateElement("name")).InnerText = requestModel.Name;
            content.AppendChild(doc.CreateElement("visits")).InnerText = requestModel.Visits.ToString();
            content.AppendChild(doc.CreateElement("date")).InnerText = requestModel.Date.ToString("yyyy-MM-dd");

            return doc;
        }
    }
}