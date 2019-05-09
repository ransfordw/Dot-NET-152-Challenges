using System;

namespace Challenge_8
{
    public enum CarMake { Ford, Toyota, Jeep, Tesla, Chevrolet, Dodge, Honda }
    public enum CarType { Van, Truck, Sedan, SUV, Crossover, Hybrid, Hatchback, Stationwagon }
    public class Car : IInsuranceMetrics
    {
        public CarMake Make { get; set; }
        public CarType Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public bool IsLuxury { get; set; }
        public bool HasAccident { get; set; }
        public TimeSpan TimeSpeeding { get; set; }
        public int TimesOutOfLane { get; set; }
        public int RollingStops { get; set; }
        public int TimesTailgating { get; set; }

        public Car() { }

        public Car(CarMake make, CarType type, int year, int miles, bool isLuxury, bool hasAccident, TimeSpan speeding, int outOfLane, int rollingStops, int timesTailgating)
        {
            Make = make;
            Model = type;
            Year = year;
            Miles = miles;
            IsLuxury = isLuxury;
            HasAccident = hasAccident;
            TimeSpeeding = speeding;
            TimesOutOfLane = outOfLane;
            RollingStops = rollingStops;
            TimesTailgating = timesTailgating;
        }
    }
}