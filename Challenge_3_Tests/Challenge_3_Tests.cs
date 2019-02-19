using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class Challenge_3_Tests
    {
        private OutingRepository _outingRepoTest;
        private Outing royalPin;
        private Outing golf;
        private Outing concert;

        [TestInitialize]
        public void Arrange()
        {
            _outingRepoTest = new OutingRepository();
            royalPin = new Outing(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m);
            golf = new Outing(EventType.Golf, 2, "5/05/2018", 35.0m, 70.0m);
            concert = new Outing(EventType.Concert, 2, "6/23/2018", 15.00m, 30.0m);
        }

        [TestMethod]
        public void OutingRepository_AddToList_ShouldIncreaseCountByOne()
        {
            //This test also handles the GetList method
            _outingRepoTest.AddToList(royalPin);

            var actual = _outingRepoTest.GetList().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_AddToListByType_ShouldIncreaseCountByOne()
        {
            var list = _outingRepoTest.GetNewListByType();
            _outingRepoTest.AddToListByType(royalPin);

            var actual = list.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_EventTypeSwitch_ShouldReturnCorrectType()
        {
            int i = 3;

            var actual = _outingRepoTest.EventTypeSwitch(i);
            var expected = EventType.AmusmentPark;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_AddOutingToListByType_ShouldAddCorrectOuting()
        {
            var outings = _outingRepoTest.GetList();
            _outingRepoTest.AddToList(royalPin);
            _outingRepoTest.AddToList(golf);

            var outingsByType = _outingRepoTest.GetNewListByType();

            _outingRepoTest.AddOutingToListByType(golf.Category);
            var actual = outingsByType.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_ReturnDesiredCostByType_ShouldReturnCorrectDecimal()
        {
            var outings = _outingRepoTest.GetNewListByType();
            _outingRepoTest.AddToListByType(concert);
            _outingRepoTest.AddToListByType(golf);

            var actual = _outingRepoTest.ReturnDesiredCostByType();
            var expected = 100.0m;

            Assert.AreEqual(expected, actual);
        }
    }
}
