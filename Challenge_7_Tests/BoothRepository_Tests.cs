using System;
using Challenge_7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_7_Tests
{
    [TestClass]
    public class BoothRepository_Tests
    {
        BoothRepository _boothRepo;

        [TestInitialize]
        public void Arrange()
        {
             _boothRepo = new BoothRepository();

        }

        [TestMethod]
        public void BoothRepositort_GetParties_ShouldReturnCorrectCount()
        {
            var parties = _boothRepo.GetParties();

            var actual = parties.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
