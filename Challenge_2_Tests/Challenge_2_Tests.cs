using System;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
    [TestClass]
    public class Challenge_2_Tests
    {
        private ClaimRepository _claimRepoTest;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepoTest = new ClaimRepository();
        }

        [TestMethod]
        public void ClaimsRepository_AddItemToQueue_ShouldIncreaseCountByOne()
        {
            Claim bob = new Claim(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            _claimRepoTest.AddClaimToQueue(bob);

            //GetClaims method is tested within this method as well.
            var actual = _claimRepoTest.GetClaims().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_RemoveQueueItem_ShouldDecreaseCountByOne()
        {
            Claim bob = new Claim(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            Claim sue = new Claim(2, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018", true);
            _claimRepoTest.AddClaimToQueue(bob);
            _claimRepoTest.AddClaimToQueue(sue);

            _claimRepoTest.RemoveQueueItem();

            var actual = _claimRepoTest.GetClaims().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_ValidateClaim_ShouldReturnBoolean()
        {
            var claimDate = "7/29/2018";
            var incidentDate = "5/22/2018";

            var actual = _claimRepoTest.ValidateClaim(claimDate, incidentDate);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_ClaimTypeSwitch_ShouldReturnCorrectType()
        {
            int i = 3;

            var actual = _claimRepoTest.ClaimTypeSwitch(i);
            var expected = TypeOfClaim.Theft;

            Assert.AreEqual(expected, actual);
        }
    }
}
