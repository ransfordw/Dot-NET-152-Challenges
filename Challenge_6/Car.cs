using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public enum CarType { Gas = 1, Hybrid, Electric}
    public class Car
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public CarType FuelType { get; set; }
        public int MilesPer { get; set; }

        public Car() { }
        public Car(string make, string model, CarType type, int milesPer)
        {
            CarMake = make;
            CarModel = model;
            FuelType = type;
            MilesPer = milesPer;
        }
    }
}
