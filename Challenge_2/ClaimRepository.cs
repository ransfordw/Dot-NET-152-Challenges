using System;
using System.Collections.Generic;

namespace Challenge_2
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimsQueue = new Queue<Claim>();
        private bool _isValid;
        private TypeOfClaim _type;

        public Queue<Claim> GetClaims()
        {
            return _claimsQueue;
        }

        public void AddClaimToQueue(Claim claim)
        {
            _claimsQueue.Enqueue(claim);
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
