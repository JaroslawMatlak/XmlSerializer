using System;
using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class SwaggerController : ApiController
    {
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\SerializerApi.xml.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
