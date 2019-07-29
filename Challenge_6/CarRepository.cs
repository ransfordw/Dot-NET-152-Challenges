using System;
using System.Collections.Generic;

namespace Challenge_6
{
    public class CarRepository
    {
        private readonly List<Car> _cars;
        private CarType _type;
        private int _index = 1;

        public CarRepository()
        {
            _cars = new List<Car>();
        }

        public List<Car> GetCarList()
        {
            return _cars;
        }

        public void AddCarToList(Car car)
        {
            if (car != null)
                _cars.Add(car);
            else
                throw new NullReferenceException("There was no information for the desired car");
        }

        public CarType GetFuelType(int fuelInput)
        {
            switch (fuelInput)
            {
                case 1:
                    _type = CarType.Gas;
                    break;
                case 2:
                    _type = CarType.Hybrid;
                    break;
                default:
                    _type = CarType.Electric;
                    break;
            }
            return _type;
        }

        public Car CreateCar(string make, string model, CarType type, int fuelage)
        {
            Car newCar = new Car()
            {
                CarID = _index,
                CarMake = make,
                CarModel = model,
                FuelType = type,
                MilesPer = fuelage
            };
            _index++;
            return newCar;
        }

        public bool YesNoResponse(string response)
        {
            if (response.ToLower().Contains("y"))
                return true;
            else
                return false;
        }

        public void RemoveCar(Car c)
        {
            if (c == null)
                throw new NullReferenceException("Cannont remove \"null\" from list.");
            if (_cars.Contains(c))
                _cars.Remove(c);
            else
                throw new Exception("The car did not exist.");
        }
    }
}
