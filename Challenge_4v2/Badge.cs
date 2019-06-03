using System.Collections.Generic;

namespace Challenge_4v2
{
    public class Badge
    {
        public Badge() { }

        public Badge(int badgeNum, List<Door> doors)
        {
            BadgeNum = badgeNum;
            Doors = doors;
        }

        public List<Door> Doors { get; set; }
        public int BadgeNum { get; set; }
    }
}
