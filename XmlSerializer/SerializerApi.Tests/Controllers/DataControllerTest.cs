using NUnit.Framework;
using SerializerApi.Controllers;
using SerializerApi.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SerializerApi.ModelContext;
using SerializerApi.Json;
using SerializerApi.Models;
using System.Net.Http;

namespace SerializerApi.Tests.Controllers
{
    [TestFixture]
    public class DataControllerTest
    {
        private DataController _dataController;

        public DataControllerTest()
        {
            var jsonConverter = new Json.JsonConverter();
            var mockDataContext = new Mock<ISerializerDataContext>();

            var rm = It.IsAny<RequestModel>();
            mockDataContext.Setup(m => m.RequestModels.Add(rm)).Returns(rm);
            mockDataContext.Setup(m => m.SaveChanges()).Returns(0);

            _dataController = new DataController(jsonConverter, mockDataContext.Object);
        }


        [Test]
        [TestCase("[{\"ix\": 10,\"name\": \"test\", \"visits\": 5 ,\"date\": \"2018 - 01 - 01\"},{}]")]
        public void PostTest_Valid(string jsonString)
        {
            try
            {
                var request = CreateRequest(jsonString);
                _dataController.Post(request);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        [TestCase("blahblahblah")]
        [TestCase(null)]
        public void PostTest_Invalid(string jsonString)
        {
            try
            {
                var request = CreateRequest(jsonString);
                _dataController.Post(request);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        private HttpRequestMessage CreateRequest(string jsonString)
        {
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Content = content
            };
            return request;
        }
    }
}
