using System.Collections.Generic;

namespace Challenge_6
{
    public class CarRepository
    {
        private List<Car> _cars = new List<Car>();
        private CarType _type;

        public List<Car> GetCarList()
        {
            return _cars;
        }

        public void AddCarToList(Car car)
        {
            _cars.Add(car);
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
                CarMake = make,
                CarModel = model,
                FuelType = type,
                MilesPer = fuelage
            };
            return newCar;
        }

        public bool YesNoResponse(string response)
        {
            response.ToLower();
            if (response.Contains("y"))
                return true;
            else
                return false;
        }

        public void RemoveCar(Car c)
        {
            _cars.Remove(c);
        }
    }
}
