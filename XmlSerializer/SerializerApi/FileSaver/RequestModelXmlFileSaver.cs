using SerializerApi.Models;
using SerializerApi.XmlConverter;

namespace SerializerApi.FileSaver
{
    public class RequestModelXmlFileSaver :IRequestModelXmlFileSaver
    {
        private IXmlConverter _xmlConverter;
        public RequestModelXmlFileSaver(IXmlConverter xmlConverter)
        {
            _xmlConverter = xmlConverter;
        }
        

        public void SaveRequestModelXmlFile(RequestModel request)
        {
            if (request == null)
                return;
            var xmlDocument = _xmlConverter.RequestModelToXml(request);

            var path = BuildPath(request);
            var filename = BuildFileName(request);

            xmlDocument.Save($"{path}/{filename}");
        }

        public string BuildPath(RequestModel request)
        {
            if (request == null)
                return null;
            var path = "./App_Data/xml/";
            path += request.Date.ToString("yyyy-MM-dd");

            var exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            return path;
        }
        public string BuildFileName(RequestModel request)
        {
            if (request == null)
                return null;
            var filename = request.Index.ToString() + ".xml";
            return filename;
        }
    }
}