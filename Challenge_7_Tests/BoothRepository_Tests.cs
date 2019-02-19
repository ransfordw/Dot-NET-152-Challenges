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

        //Get Lists
        [TestMethod]
        public void BoothRepository_GetParties_ShouldReturnCorrectCount()
        {
            var parties = _boothRepo.GetParties();

            var actual = parties.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoothRepository_GetAllBooths_ShouldReturnCorrectCount()
        {
            var booths = _boothRepo.GetAllBooths();

            var actual = booths.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoothRepository_GetDessertBooths_ShouldReturnCorrectCount()
        {
            //Initializes booth lists in repository
            _boothRepo.GetBoothsByType();

            var desserts = _boothRepo.GetDessertBooths();

            var actual = desserts.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoothRepository_GetBurgerBooths_ShouldReturnCorrectCount()
        {
            //Initializes booth lists in repository
            _boothRepo.GetBoothsByType();

            var burgers = _boothRepo.GetBurgerBooths();

            var actual = burgers.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
