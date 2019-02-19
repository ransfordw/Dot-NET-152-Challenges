using Challenge_7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_7_Tests
{
    [TestClass]
    public class BoothRepository_Tests
    {
        BoothRepository _boothRepo;
        BurgerBooth _burger;
        DessertBooth _dessert;

        [TestInitialize]
        public void Arrange()
        {
            _boothRepo = new BoothRepository();
            _burger = new BurgerBooth();
            _dessert = new DessertBooth();
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

        //Add to Lists
        [TestMethod]
        public void BoothRepository_AddBoothToList_ShouldReturnCorrectCounts()
        {
            var booths = _boothRepo.GetAllBooths();
            _boothRepo.AddBoothToList(_burger);

            var actual = booths.Count;
            var expected = 1;

            _boothRepo.AddBoothToList(_dessert);

            var actualTwo = booths.Count;
            var expectedTwo = 2;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTwo, actualTwo);
        }

        [TestMethod]
        public void BoothRepository_AddPartyToList_ShouldReturnCorrectCount()
        {
            var list =_boothRepo.GetParties();
            _boothRepo.AddPartyToList(new Party());

            var actual = list.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }


    }
}
