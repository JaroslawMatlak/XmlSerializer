using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SerializerApi.FileSaver;
using Moq;
using SerializerApi.XmlConverting;
using SerializerApi.Models;
using System.Xml;

namespace SerializerApi.Tests.FileSaver
{
    [TestFixture]
    public class RequestModelXmlFileSaverTest
    {
        private IRequestModelXmlFileSaver _requestModelXmlFileSaver;

        public RequestModelXmlFileSaverTest()
        {
            var mockConverter = new Mock<IXmlConverter>();

            var sampleXmlDocument = new XmlDocument();
            sampleXmlDocument.AppendChild(sampleXmlDocument.CreateElement("test"));

            mockConverter.Setup(m => m.RequestModelToXml(It.IsAny<RequestModel>())).Returns(sampleXmlDocument);

            _requestModelXmlFileSaver = new RequestModelXmlFileSaver(mockConverter.Object);
        }

        [Test]
        public void SaveXmlFilesForRequest_Valid()
        {
            var request = new RequestModel() { Index = 1, Name = "testing", Date = DateTime.Parse("2018-02-05"), Visits = 4 };
            var path = _requestModelXmlFileSaver.BuildPath(request);
            var fileName = _requestModelXmlFileSaver.BuildFileName(request);

            var fullPath = $"{path}/{fileName}";

            _requestModelXmlFileSaver.SaveRequestModelXmlFile(request);

            Assert.IsTrue(System.IO.File.Exists(fullPath));
        }
    }
}
