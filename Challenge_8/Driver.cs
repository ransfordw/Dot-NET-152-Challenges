using System;
using System.Collections.Generic;

namespace Challenge_8
{
    public class Driver : IInsuranceMetrics
    {
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
            get => CalculatePremiumModifier();
          //  set { premiumModifier = CalculatePremiumModifier(); }
        }

        public string FullName
        {
            get => LastName + ", " + FirstName;
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

        public Driver(TimeSpan speeding, int outOfLane, int rollingStops, int tailgating, string firstName,string lastName, int age) :this (firstName, lastName, age)
        {
            TimeSpeeding = speeding;
            TimesOutOfLane = outOfLane;
            RollingStops = rollingStops;
            TimesTailgating = tailgating;
        }

        private decimal CalculatePremiumModifier()
        {
            var speeding = CheckSpeeding();

            var lanes = CheckTimesOutOfLane();

            var rolling = CheckRollingStops();

            var tailgating = CheckTailgating();

            return speeding + lanes + rolling + tailgating;
        }

        public decimal CheckSpeeding()
        {
            if (TimeSpeeding >= new TimeSpan(1, 0, 0))
                return 0.5m;
            else if (TimeSpeeding >= new TimeSpan(0, 20, 0))
                return 0.2m;
            else
                return -0.4m;
        }

        public decimal CheckTimesOutOfLane()
        {
            if (TimesOutOfLane > 5)
                return 0.3m;
            else if (TimesOutOfLane > 2)
                return 0.1m;
            else
                return -0.4m;
        }

        public decimal CheckRollingStops()
        {
            if (RollingStops > 20)
                return 0.4m;
            else if (RollingStops > 10)
                return 0.2m;
            else
                return -0.2m;
        }

        public decimal CheckTailgating()
        {
            if (TimesTailgating > 4)
                return 0.5m;
            else if (TimesTailgating > 3)
                return 0.2m;
            else
                return -0.6m;
        }
    }
}