using System;
using System.Collections.Generic;

namespace Challenge_7
{
    public class BoothRepository
    {
        private List<IBooth> _repoBooths = new List<IBooth>();
        private List<Party> _repoParties = new List<Party>();
        private List<BurgerBooth> _repoBurgers;
        private List<DessertBooth> _repoDesserts;

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

        public List<IBooth> GetAllBooths()
        {
            return _repoBooths;
        }

        public List<DessertBooth> GetDessertBooths()
        {
            GetBoothsByType();
            return _repoDesserts;
        }

        public List<BurgerBooth> GetBurgerBooths()
        {
            GetBoothsByType();
            return _repoBurgers;
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
                booth.TicketsTaken = 0;
                foreach (var party in _repoParties)
                {
                    if (party.DessertBooth == booth)
                        booth.TicketsTaken += party.DessertTickets;
                    else if (party.BurgerBooth == booth)
                        booth.TicketsTaken += party.BurgerTickets;
                }
            }
        }

        public void SeedData()
        {
            var dessert = new DessertBooth("Mrs. Curl", 3.5m, 0.75m);
            var burger = new BurgerBooth("Bob's Burgers", 10.99m, 1.2m);
            AddBoothToList(dessert);
            AddBoothToList(burger);
            AddPartyToList(new Party("Holiday Party", burger, 12, dessert, 34));
        }

        public void GetBoothsByType()
        {
            _repoBurgers = new List<BurgerBooth>();
            _repoDesserts = new List<DessertBooth>();

            foreach (IBooth booth in _repoBooths)
            {
                if (booth.GetType() == typeof(BurgerBooth))
                    _repoBurgers.Add((BurgerBooth)booth);
                else
                    _repoDesserts.Add((DessertBooth)booth);
            }
        }
    }
}
