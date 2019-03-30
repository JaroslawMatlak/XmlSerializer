using SerializerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SerializerApi.JsonConverter
{
    public class JsonConverter:IJsonConverter
    {
        public RequestModel ConvertJsonStringToRequestModel(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<RequestModel>(jsonString);
            }
            catch(Exception ex)
            {
                throw new FormatException("Invalid format of the input Json. "+ex.Message);
            }
        }
    }
}