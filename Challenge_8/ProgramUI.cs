using System;

namespace Challenge_8
{
    internal class ProgramUI
    {
        readonly SmartCarRepository _smartRepo = new SmartCarRepository();
        internal void Run()
        {
            SeedData();
        }

        private void SeedData()
        {
            var ford = new Car(CarMake.Ford, CarType.SUV, 1993, 185000, false, true, new TimeSpan(0, 30, 0), 4, 7, 1);
            var chevy = new Car(CarMake.Chevrolet, CarType.Crossover, 1998, 200120, false, true, new TimeSpan(2, 24, 0), 1, 1, 2);
            var dodge = new Car(CarMake.Dodge, CarType.Truck, 2007, 165034, false, true, new TimeSpan(0, 5, 0), 2, 9, 1);
            var honda = new Car(CarMake.Honda, CarType.Stationwagon, 2014, 98004, false, true, new TimeSpan(0, 45, 0), 2, 3, 2);
            var tesla = new Car(CarMake.Tesla, CarType.Sedan, 2019, 15000, true, true, new TimeSpan(1, 48, 0), 0, 0, 4);

            var chuck = new Driver("Chuck", "Norris", 75);
            var karen = new Driver("Karen", "Smith", 45);

            _smartRepo.AddDriver(chuck);
            _smartRepo.AddDriver(karen);
            _smartRepo.AddCarToDriver(ford, chuck);
            _smartRepo.AddCarToDriver(chevy, chuck);
            _smartRepo.AddCarToDriver(dodge, chuck);
            _smartRepo.AddCarToDriver(honda, chuck);
            _smartRepo.AddCarToDriver(tesla, chuck);
        }
    }
}