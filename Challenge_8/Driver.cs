using System;
using System.Collections.Generic;

namespace Challenge_8
{
    public class Driver : IInsuranceMetrics
    {
        private string _fullName;
        private decimal premiumModifier;

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan TimeSpeeding { get; set; }
        public int TimesOutOfLane { get; set; }
        public int RollingStops { get; set; }
        public int TimesTailgating { get; set; }
        public List<Car> Cars { get; set; }

        public decimal PremiumModifier
        {
            get => premiumModifier;
            set { premiumModifier = CalculatePremiumModifier(); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = LastName + ", " + FirstName; }
        }

        public Driver()
        {
            Cars = new List<Car>();
        }

        public Driver(string firstName, string lastName, int age) : this ()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Driver(TimeSpan speeding, int outOfLane, int rollingStops, int tailgating) :this ()
        {
            TimeSpeeding = speeding;
            TimesOutOfLane = outOfLane;
            RollingStops = rollingStops;
            TimesTailgating = tailgating;
        }

        private decimal CalculatePremiumModifier()
        {
            decimal modifier = 0;

            //Speeding Check
            if (TimeSpeeding > new TimeSpan(0, 20, 0))
                modifier += 0.2m;
            else if (TimeSpeeding > new TimeSpan(1, 0, 0))
                modifier += 0.5m;
            else
                modifier -= 0.4m;

            //Out of Lane Check
            if (TimesOutOfLane > 2)
                modifier += 0.1m;
            else if (TimesOutOfLane > 5)
                modifier += 0.3m;
            else
                modifier -= 0.4m;

            //Rolling Stop Check
            if (RollingStops > 10)
                modifier += 0.2m;
            else if (RollingStops > 20)
                modifier += 0.4m;
            else
                modifier -= 0.2m;

            //Tailgating Check
            if (TimesTailgating > 3)
                modifier += 0.2m;
            else if (TimesTailgating > 4)
                modifier += 0.5m;
            else
                modifier -= 0.6m;

            return modifier;
        }
    }
}