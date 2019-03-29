using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class JobsController : ApiController
    {
        [HttpGet]
        [Route("api/Jobs/SaveFiles/{id}")]
        public void SaveFiles(int id)
        {

        }
    }
}
