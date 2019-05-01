using Challenge_8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_8_Tests
{
    [TestClass]
    public class Driver_Tests
    {
        [TestMethod]
        public void Driver_Constructor1_ShouldNotThrowException()
        {
            var driver = new Driver();

            Assert.IsNotNull(driver.Cars);
        }

        [DataTestMethod]
        [DataRow("Bob", "Ross", "Ross, Bob")]
        [DataRow("Chuck", "Norris", "Norris, Chuck")]
        public void Driver_FullNameProperty_ShouldReturnCorrectString(string firstName, string lastName, string expected)
        {
            var driver = new Driver(firstName, lastName, 40);

            var actual = driver.FullName;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1,0,0,0,0,0.5d)]
        [DataRow(0,20,0,0,0,0.2d)]
        [DataRow(0,15,0,0,0,-0.4d)]
        public void Driver_CheckSpeeding_ShouldReturnCorrectValue(int hours, int minutes, int outOfLane, int rollingStops, int tailgaiting, double expected)
        {
            var speeding = new TimeSpan(hours, minutes, 0);
            var driver = new Driver(speeding, outOfLane, rollingStops, tailgaiting,"bob","marley",45);

            var actual = driver.CheckSpeeding();
            Assert.AreEqual((decimal)expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 6, 0, 0, 0.3d)]
        [DataRow(0, 0, 3, 0, 0, 0.1d)]
        [DataRow(0, 0, 0, 0, 0, -0.4d)]
        public void Driver_CheckTimesOutOfLane_ShouldReturnCorrectValue(int hours, int minutes, int outOfLane, int rollingStops, int tailgaiting, double expected)
        {
            var speeding = new TimeSpan(hours, minutes, 0);
            var driver = new Driver(speeding, outOfLane, rollingStops, tailgaiting, "bob", "marley", 45);

            var actual = driver.CheckTimesOutOfLane();
            Assert.AreEqual((decimal)expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0, 21, 0, 0.4d)]
        [DataRow(0, 0, 0, 11, 0, 0.2d)]
        [DataRow(0, 0, 0, 0, 0, -0.2d)]
        public void Driver_CheckRollingStops_ShouldReturnCorrectValue(int hours, int minutes, int outOfLane, int rollingStops, int tailgaiting, double expected)
        {
            var speeding = new TimeSpan(hours, minutes, 0);
            var driver = new Driver(speeding, outOfLane, rollingStops, tailgaiting, "bob", "marley", 45);

            var actual = driver.CheckRollingStops();
            Assert.AreEqual((decimal)expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0, 0, 5, 0.5d)]
        [DataRow(0, 0, 0, 0, 4, 0.2d)]
        [DataRow(0, 0, 0, 0, 0, -0.6d)]
        public void Driver_CheckTailgating_ShouldReturnCorrectValue(int hours, int minutes, int outOfLane, int rollingStops, int tailgaiting, double expected)
        {
            var speeding = new TimeSpan(hours, minutes, 0);
            var driver = new Driver(speeding, outOfLane, rollingStops, tailgaiting, "bob", "marley", 45);

            var actual = driver.CheckTailgating();
            Assert.AreEqual((decimal)expected, actual);
        }

        [DataTestMethod]
        [DataRow(0,5, 0, 0, 0,-1.6d)]
        [DataRow(0,21, 3, 21, 0,0.1d)]
        public void Driver_CalculatePremiumModifierGetter_ShouldReturnCorrectDecimal(int hours, int minutes, int outOfLane, int rollingStops, int tailgaiting, double expected)
        {
            var speeding = new TimeSpan(hours, minutes, 0);
            var driver = new Driver(speeding, outOfLane, rollingStops, tailgaiting, "bob", "marley", 45);

            var actual = driver.PremiumModifier;


            Assert.AreEqual((decimal)expected, actual);
        }
    }
}
