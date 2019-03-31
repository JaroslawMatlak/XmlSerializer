using Newtonsoft.Json;
using System;

namespace SerializerDataGenerator
{
    public class RequestModel
    {
        [JsonProperty("ix")]
        public int Index { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("visits")]
        public int? Visits { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
