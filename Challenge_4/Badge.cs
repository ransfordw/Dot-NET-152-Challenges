using System.Collections.Generic;

namespace Challenge_4
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeNum, List<string> doorList)
        {
            BadgeNum = badgeNum;
            DoorList = doorList;
        }

        public int BadgeNum { get; set; }
        public List<string> DoorList { get; set; }
    }
}
