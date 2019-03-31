using SerializerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SerializerApi.Json
{
    public class JsonConverter:IJsonConverter
    {
        public IEnumerable<RequestModel> ConvertJsonStringToRequestModels(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<RequestModel>>(jsonString);
            }
            catch(Exception ex)
            {
                throw new FormatException("Invalid format of the input Json. "+ex.Message);
            }
        }
    }
}