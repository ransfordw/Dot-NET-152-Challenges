using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
