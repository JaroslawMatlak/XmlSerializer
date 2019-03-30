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

        public int CompareTo(RequestModel other)
        {
            if (other == null)
                return 1;

            var comparisonSum = 0;
            comparisonSum += Index.CompareTo(other.Index);

            if (Name != null)
                comparisonSum += Name.CompareTo(other.Name);
            else
                comparisonSum += (other.Name == null) ? 0 : 1;

            if(Visits!= null)
                comparisonSum += ((int)Visits).CompareTo(other.Visits);
            else
                comparisonSum += (other.Visits == null) ? 0 : 1;

            comparisonSum += Date.CompareTo(other.Date);

            return comparisonSum == 0 ? 0 : 1;
        }
    }
}