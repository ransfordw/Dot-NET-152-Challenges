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
            Claim bob = new Claim(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018");
            _claimRepoTest.AddClaimToQueue(bob);

            //GetClaims method is tested within this method as well.
            var actual = _claimRepoTest.GetClaims().Count;
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_RemoveQueueItem_ShouldDecreaseCountByOne()
        {
            Claim bob = new Claim(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018");
            Claim sue = new Claim(2, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018");
            _claimRepoTest.AddClaimToQueue(bob);
            _claimRepoTest.AddClaimToQueue(sue);

            _claimRepoTest.RemoveQueueItem();

            var actual = _claimRepoTest.GetClaims().Count;
            var expected = 3;

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

        [DataTestMethod]
        [DataRow("2/2/2019", "2/2/2018", false)]
        [DataRow("2/12/2019", "2/2/2019", true)]
        public void Claim_ValidateClaim_ReturnsCorrectBoolean(string claimDate, string incidentDate, bool expected)
        {
            Claim claim = new Claim(1, TypeOfClaim.Car, "description", 123m, claimDate, incidentDate);

            var actual = claim.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("2/2/2019", "2/2/2018", 365)]
        [DataRow("2/12/2019", "2/2/2019", 10)]
        [DataRow("3/15/2019", "1/2/2019", 72)]
        public void Claim_SetTimeSpan_ReturnsValue(string claimDate, string incidentDate, int expected)
        {
            Claim claim = new Claim(1, TypeOfClaim.Car, "description", 123m, claimDate, incidentDate);

            var actual = claim.TimeSinceIncident.Days;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, true)]
        [DataRow(8, true)]
        [DataRow(9, false)]
        [DataRow(10, true)]
        [DataRow(11, false)]
        [DataRow(12, true)]
        public void ClaimRepo_MonthHas31Days_ReturnsTrueForCorrectMonths(int monthResponse, bool expected)
        {
            var month = monthResponse;
            var actual = _claimRepoTest.MonthHas31Days(month);
            
            Assert.AreEqual(expected, actual,$"Month: {month}");
        }

    }
}
