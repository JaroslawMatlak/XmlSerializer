using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SerializerApi.Models
{
    [Table("dbo.Requests")]
    public class RequestModel 
    {
        [Key]
        [JsonProperty("ix")]
        public int Index { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("visits")]
        public int? Visits { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (other.GetType() != GetType())
                return false;

            var otherAsRequestModel = (RequestModel)other;
            var comparisonSum = 0;
            comparisonSum += Index.CompareTo(otherAsRequestModel.Index);

            if (Name != null)
                comparisonSum += Name.CompareTo(otherAsRequestModel.Name);
            else
                comparisonSum += (otherAsRequestModel.Name == null) ? 0 : 1;

            if(Visits!= null)
                comparisonSum += ((int)Visits).CompareTo(otherAsRequestModel.Visits);
            else
                comparisonSum += (otherAsRequestModel.Visits == null) ? 0 : 1;

            comparisonSum += Date.CompareTo(otherAsRequestModel.Date);

            return comparisonSum == 0;
        }
    }
}