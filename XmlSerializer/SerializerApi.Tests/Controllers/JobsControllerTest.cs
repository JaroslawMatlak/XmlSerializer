using Moq;
using NUnit.Framework;
using SerializerApi.Controllers;
using SerializerApi.FileSaver;
using SerializerApi.ModelContext;
using SerializerApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SerializerApi.Tests.Controllers
{
    [TestFixture]
    public class JobsControllerTest
    {
        private JobsController _jobsController;
        public JobsControllerTest()
        {
            var mockDataContext = new Mock<ISerializerDataContext>();
            var listOfSampleRequests = new List<RequestModel>();
            var myDbSet = GetQueryableMockDbSet(listOfSampleRequests);
            mockDataContext.Setup(m => m.RequestModels).Returns(myDbSet);

            var mockRequestModelFileSaver = new Mock<IRequestModelXmlFileSaver>();
            mockRequestModelFileSaver.Setup(m => m.SaveRequestModelXmlFile(It.IsAny<RequestModel>())).Callback(()=> { return; });

            _jobsController = new JobsController(mockDataContext.Object, mockRequestModelFileSaver.Object);
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }

        [Test]
        public void SaveFilesTest()
        {
            try
            {
                _jobsController.SaveFiles();
            }
            catch
            {
                Assert.Fail();
            }

        }
    }
}
