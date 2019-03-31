using System;
using NUnit.Framework;
using SerializerApi.Models;
using System.Xml;
using System.IO;

namespace SerializerApi.Tests.XmlConverter
{
    [TestFixture]
    public class XmlConverterTest
    {
        private XmlConverting.XmlConverter _xmlConverter;

        public XmlConverterTest()
        {
            _xmlConverter = new XmlConverting.XmlConverter();
        }

        [Test]
        public void RequestModelToXmlTest_AllDataGiven()
        {
            var requestModelWithAllData = new RequestModel() { Index = 1, Date = DateTime.Parse("2018-01-01"), Name = "given name", Visits = 5 };
            var expectedValue = "<?xml version=\"1.0\" encoding=\"utf-16\"?><request><ix>1</ix><content><name>given name</name><visits>5</visits><date>2018-01-01</date></content></request>";

            var actualValue = _xmlConverter.RequestModelToXml(requestModelWithAllData);
            var actualValueXmlString = XmlDocumentToString(actualValue);
            Assert.AreEqual(expectedValue, actualValueXmlString);
        }

        [Test]
        public void RequestModelToXmlTest_NoName()
        {
            var requestModelWithNoName = new RequestModel() { Index = 1, Date = DateTime.Parse("2018-01-01"), Name = null, Visits = 5 };
            var expectedValue = "<?xml version=\"1.0\" encoding=\"utf-16\"?><request><ix>1</ix><content><visits>5</visits><date>2018-01-01</date></content></request>";

            var actualValue = _xmlConverter.RequestModelToXml(requestModelWithNoName);
            var actualValueXmlString = XmlDocumentToString(actualValue);
            Assert.AreEqual(expectedValue, actualValueXmlString);
        }
        [Test]
        public void RequestModelToXmlTest_NullRequest()
        {
            var actualValue = _xmlConverter.RequestModelToXml(null);

            Assert.IsNull(actualValue);
        }

        private string XmlDocumentToString(XmlDocument xmlDocument)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDocument.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
