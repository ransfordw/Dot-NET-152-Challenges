using System;
using System.Collections.Generic;

namespace Challenge_2
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimsQueue;
        private TypeOfClaim _type;
        private int _index;

        public ClaimRepository()
        {
            _claimsQueue = new Queue<Claim>();
            SeedData();

        }
        private void SeedData()
        {
            AddClaimToQueue(new Claim(_index, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018"));
            AddClaimToQueue(new Claim(_index, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018"));
        }
        public Queue<Claim> GetClaims()
        {
            return _claimsQueue;
        }

        public void AddClaimToQueue(Claim claim)
        {
            claim.ClaimID = _index;
            _claimsQueue.Enqueue(claim);
            _index++;
        }

        public Queue<Claim> RemoveQueueItem()
        {
            _claimsQueue.Dequeue();
            return _claimsQueue;
        }

        public TypeOfClaim ClaimTypeSwitch(int input)
        {
            switch (input)
            {
                case 1:
                    _type = TypeOfClaim.Car;
                    break;
                case 2:
                    _type = TypeOfClaim.Home;
                    break;
                case 3:
                    _type = TypeOfClaim.Theft;
                    break;
                default:
                    _type = TypeOfClaim.Other;
                    break;
            }
            return _type;
        }
    }
}
