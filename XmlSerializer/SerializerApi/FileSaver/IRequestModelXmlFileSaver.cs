using SerializerApi.Models;

namespace SerializerApi.FileSaver
{
    public interface IRequestModelXmlFileSaver
    {
        void SaveRequestModelXmlFile(RequestModel request);
        string BuildPath(RequestModel request);
        string BuildFileName(RequestModel request);
    }
}
