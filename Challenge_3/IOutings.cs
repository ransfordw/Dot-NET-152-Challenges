using System.Collections.Generic;

namespace Challenge_3
{
    public interface IOutings
    {
        List<Outing> GetList();
        List<Outing> GetNewListByType();
        void AddToList(Outing outing);
        void AddToListByType(Outing outing);
        EventType EventTypeSwitch(int input);
        void AddOutingToListByType(EventType type);
        decimal ReturnDesiredCostByType();
    }
}
