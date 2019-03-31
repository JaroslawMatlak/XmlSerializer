using SerializerApi.FileSaver;
using SerializerApi.ModelContext;
using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class JobsController : ApiController
    {
        private readonly ISerializerDataContext _dbContext;
        private readonly IRequestModelXmlFileSaver _requestModelXmlFileSaver;
        public JobsController(ISerializerDataContext dbContext,
            IRequestModelXmlFileSaver requestModelXmlFileSaver)
        {
            _dbContext=dbContext;
            _requestModelXmlFileSaver = requestModelXmlFileSaver;
        }

        /// <summary>
        /// This endpoint invokes an internal job of selecting the
        /// database records and then serializes each table record as an XML file.The files are
        /// saved in App_Data\xml\yyyy-MM-dd based on the date value in the models
        /// </summary>
        [HttpGet]
        [Route("api/Jobs/SaveFiles")]
        public void SaveFiles()
        {
            var requestModels = _dbContext.RequestModels;
            foreach (var requestModel in requestModels)
            {
                _requestModelXmlFileSaver.SaveRequestModelXmlFile(requestModel);
            }
        }
    }
}
