using System;
using System.Collections.Generic;

namespace Challenge_8
{
    public class Driver
    {
        private string _fullName;

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan TimeSpeeding { get; set; }
        public int TimesOutOfLane { get; set; }
        public int RollingStops { get; set; }
        public int TimesTailgating { get; set; }
        public decimal PremiumModifier { get; set; }

        public string FullName
        {
            get => _fullName;
            set { _fullName = LastName + ", " + FirstName; }
        }

        public List<Car> Cars { get; set; }
    }
}