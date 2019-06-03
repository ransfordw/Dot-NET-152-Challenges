using System.Collections.Generic;

namespace Challenge_4v2
{
    public class Door 
    {
        public int DoorID { get; set; }
        public string DoorName { get; set; }

        public override string ToString()
        {
            return DoorName;
        }

        public Door()
        {
        }

        public Door(int id, string name) 
        {
            DoorID = id;
            DoorName = name;
        }
    }
}