using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SerializerApi.JsonConverter;
using SerializerApi.Models;
using System;

namespace SerializerApi.Tests.JsonConverter
{
    [TestFixture]
    public class JsonConverterTest
    {
        private readonly IJsonConverter _jsonConverter;

        public JsonConverterTest()
        {
            _jsonConverter = new SerializerApi.JsonConverter.JsonConverter();
        }

        [Test]
        public void ConvertJsonStringToRequestModel_Proper()
        {
            var jsonString = "[{\"ix\": 10, \"name\": \"test\", \"visits\": 5 ,\"date\": \"2018-01-01\"},"
                +"{\"ix\": 11, \"name\": \"test1\", \"visits\": 6 ,\"date\": \"2018-01-02\"}]";
            var expectedValue = new List<RequestModel>()
            {
                new RequestModel() { Index = 10, Name = "test", Visits = 5, Date = DateTime.Parse("2018-01-01") },
                new RequestModel() { Index = 11, Name = "test1", Visits = 6, Date = DateTime.Parse("2018-01-02") }
            };

            var actualValue=_jsonConverter.ConvertJsonStringToRequestModels(jsonString);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        [TestCase("blahblahbla")]
        [TestCase(null)]
        public void ConvertJsonStringToRequestModel_Invalid(string jsonString)
        {
            try
            {
                var actualValue = _jsonConverter.ConvertJsonStringToRequestModels(jsonString);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }
    }
}
