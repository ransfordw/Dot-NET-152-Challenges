using System;
using System.Collections.Generic;

namespace Challenge_4v2
{
    internal class BadgeRepository
    {
        private readonly Dictionary<int, List<Door>> _badges = new Dictionary<int, List<Door>>();
        private readonly List<Door> _allDoors = new List<Door>();

        internal Dictionary<int, List<Door>> GetAllBadges()
        {
            return _badges;
        }

        internal List<Door> GetAllDoors()
        {
            return _allDoors;
        }

        internal void AddBadgeToDictionary(Badge newBadge)
        {
            _badges.Add(newBadge.BadgeNum, newBadge.Doors);
        }

        internal void AddNewDoorToAllDoors(Door door)
        {
            _allDoors.Add(door);
        }
    }
}