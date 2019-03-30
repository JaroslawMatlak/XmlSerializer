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
using SerializerApi.JsonConverter;
using SerializerApi.Models;

namespace SerializerApi.Tests.Controllers
{
    [TestFixture]
    public class DataControllerTest
    {
        private readonly IJsonConverter _jsonConverter;
        private Mock<ISerializerDataContext> _mockDataContext;
        private DataController _dataController;

        public DataControllerTest()
        {
            _jsonConverter = new SerializerApi.JsonConverter.JsonConverter();
            _mockDataContext = new Mock<ISerializerDataContext>();

            var rm = It.IsAny<RequestModel>();
            _mockDataContext.Setup(m => m.RequestModels.Add(rm)).Returns(rm);
            _mockDataContext.Setup(m => m.SaveChanges()).Returns(0);

            _dataController = new DataController(_jsonConverter, _mockDataContext.Object);
        }


        [Test]
        [TestCase("{\"ix\": 10,\"name\": \"test\", \"visits\": 5 ,\"date\": \"2018 - 01 - 01\"}")]
        public void PostTest_Valid(string jsonString)
        {
            try
            {
                _dataController.Post(jsonString);
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
                _dataController.Post(jsonString);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }
    }
}
