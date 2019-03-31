using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SerializerDataGenerator
{
    public static class HttpDataSender
    {
        public async static void SendRequestModelsCollectionToSerializerApi(List<RequestModel> requestModels)
        {
            var json = JsonConvert.SerializeObject(requestModels);

            string path = Properties.Settings.Default.SerializerApiPath + Properties.Settings.Default.PostDataApiPath;

            using (var client = new HttpClient())
            {
                var uri = new Uri(path);
               
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(uri, stringContent);
            }
        }
    }
}
