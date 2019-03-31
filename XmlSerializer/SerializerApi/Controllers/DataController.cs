using SerializerApi.Json;
using SerializerApi.ModelContext;
using System.Net.Http;
using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class DataController : ApiController
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly ISerializerDataContext _dbContext;
        public DataController(IJsonConverter jsonConverter, ISerializerDataContext dbContext) : base()
        {
            _jsonConverter = jsonConverter;
            _dbContext = dbContext;
        }

        /// <summary>
        /// This endpoint receives a collection of serialized JSON models and stores them in a database created using automated database migrations.
        /// </summary>
        /// <param name="message">The request objects in JSON should have the following structure:
        /// {"ix": INT,
        ///  "name": STRING,
        ///  "visits": INT?,
        ///  "date": DATETIME}
        /// </param>
        //public void Post([FromBody]string value)
        public void Post(HttpRequestMessage message)
        {
            var json = message.Content.ReadAsStringAsync().Result;
            var requestModels = _jsonConverter.ConvertJsonStringToRequestModels(json);
            _dbContext.RequestModels.AddRange(requestModels);
            _dbContext.SaveChanges();
        }
    }
}
