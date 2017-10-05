using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompactDiscDAO.Test
{
    [TestClass]
    public class TestCompactDiscService
    {
        [TestMethod]
        public void AddCompacDiscTriggersAddMethodCallOnDao()
        {
            // arrange
            var mockDao = new Mock<CompactDiscDao>();
            CompactDiscService serviceUnderTest = new CompactDiscService();
            serviceUnderTest.DiscDao = mockDao.Object;

            // act
            serviceUnderTest.GetCatalog();

            // assert
            mockDao.Verify(mock => mock.GetAllDiscs(), Times.Once());

        }
    }
}
