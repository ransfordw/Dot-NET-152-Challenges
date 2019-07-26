using System.Collections.Generic;

namespace Challenge_3
{
    public class OutingRepository : IOutingRepository
    {
        private readonly List<Outing> _outingsList;
        private readonly List<Outing> _outingsByType;
        private EventType _type;

        public OutingRepository()
        {
            _outingsList = new List<Outing>()
            {
                new Outing(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m),
                new Outing(EventType.Concert, 6, "8/26/2018", 26.0m, 156.0m),
                new Outing(EventType.Golf, 4, "7/31/2018", 15.0m, 60.0m),
                new Outing(EventType.Golf, 4, "6/30/2018", 25.0m, 100.0m)
            };
            _outingsByType = new List<Outing>();
        }
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
