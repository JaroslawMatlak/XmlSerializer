using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class DataController : ApiController
    {
        /// <summary>
        /// This endpoint receives a collection of serialized JSON models and stores them in a database created using automated database migrations.
        /// </summary>
        /// <param name="value">The request objects in JSON should have the following structure:
        /// {"ix": INT,
        ///  "name": STRING,
        ///  "visits": INT?,
        ///  "date": DATETIME}
        /// </param>
        public void Post([FromBody]string value)
        {
        }
    }
}
