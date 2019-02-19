using System.Collections.Generic;

namespace Challenge_7
{
    class BoothRepository
    {
        private List<IBooth> _repoBooths = new List<IBooth>();
        private List<Party> _repoParties = new List<Party>();

        public decimal GetMiscCost(int boothTypeResponse)
        {
            decimal miscCost = 0;
            switch (boothTypeResponse)
            {
                case 1: //burger
                    miscCost = 1.25m;
                    return miscCost;
                default: // dessert
                    miscCost = 0.80m;
                    return miscCost;
            }
        }

        public List<Party> GetParties()
        {
            return _repoParties;
        }

        public List<IBooth> GetBooths()
        {
            return _repoBooths;
        }

        public void AddBoothToList(IBooth booth)
        {
            _repoBooths.Add(booth);
        }

        public void AddPartyToList(Party party)
        {
            _repoParties.Add(party);
        }

        public void GetBoothTickets()
        {
            foreach (var booth in _repoBooths)
            {
                foreach (var party in _repoParties)
                {
                    if (party.DessertBooth == booth)
                        booth.TicketsTaken += party.DessertTickets;
                    else if (party.BurgerBooth == booth)
                        booth.TicketsTaken += party.BurgerTickets;
                }
            }
        }
    }
}
