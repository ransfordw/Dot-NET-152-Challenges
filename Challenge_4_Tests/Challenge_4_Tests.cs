using System;
using System.Collections.Generic;
using Challenge_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_4_Tests
{
    [TestClass]
    public class Challenge_4_Tests
    {
        private BadgeRepository _doorAccessList;
        private List<string> _newList;
        private Dictionary<int, List<string>> _dictionary;

        [TestInitialize]
        public void Arrange()
        {
            _doorAccessList = new BadgeRepository();
            _newList = new List<string>();
            _dictionary = new Dictionary<int, List<string>>();
        }

        [TestMethod]
        public void BadgeRepository_AddToList_ShouldIncreaseCountByOne()
        {
            _doorAccessList.AddDoorToList("A1");

            var actual = _doorAccessList.GetList().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_RemoveDoorFromList_ShouldDecreaseCountByOne()
        {
            _doorAccessList.AddDoorToList("A1");
            _doorAccessList.AddDoorToList("A2");
            _doorAccessList.RemoveDoorFromList("A1");

            var actual = _doorAccessList.GetList().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_AddBadgeToDictionary_ShouldIncreaseCountByOne()
        {
            _doorAccessList.AddDoorToList("A1");
            _doorAccessList.GetList();
            Badge badge = new Badge(1, _newList);
            _doorAccessList.AddBadgeToDictionary(badge);

            var actual = _doorAccessList.GetDictionary().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_ListToString_StringsShouldBeEqual()
        {
            _newList.Add("A1");
            _newList.Add("A2");
            _doorAccessList.GetList();

            var actual = _doorAccessList.ListToString(_newList);
            var expected = "A1, A2";

            Assert.AreEqual(expected, actual);
        }
    }
}
