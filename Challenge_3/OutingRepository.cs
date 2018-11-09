using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository : IOutings
    {
        private List<Outing> _outingsList = new List<Outing>();
        private List<Outing> _outingsByType = new List<Outing>();
        private EventType _type;

        public List<Outing> GetList()
        {
            return _outingsList;
        }
        public List<Outing> GetNewListByType()
        {
            _outingsByType.RemoveAll(outing => outing.TotalEventCost > 0m);
            return _outingsByType;
        }
        public void AddToList(Outing outing)
        {
            _outingsList.Add(outing);
        }
        public void AddToListByType(Outing outing)
        {
            _outingsByType.Add(outing);
        }
        public EventType EventTypeSwitch(int input)
        {
            switch (input)
            {
                case 1:
                    _type = EventType.Golf;
                    break;
                case 2:
                    _type = EventType.Bowling;
                    break;
                case 3:
                    _type = EventType.AmusmentPark;
                    break;
                case 4:
                    _type = EventType.Concert;
                    break;
                default:
                    _type = EventType.Other;
                    break;
            }
            return _type;
        }
        public void AddOutingToListByType(EventType type)
        {
            
            foreach (Outing outing in _outingsList)
            {
                if (outing.Category == type)
                    _outingsByType.Add(outing);
            }
        }
        public decimal ReturnDesiredCostByType()
        {
            decimal sum = 0m;
            foreach (Outing thisOuting in _outingsByType)
                sum += thisOuting.TotalEventCost;
            return sum;
        }
    }
}
