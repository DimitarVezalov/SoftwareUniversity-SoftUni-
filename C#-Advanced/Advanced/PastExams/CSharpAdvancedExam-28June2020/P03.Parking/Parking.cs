using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly ICollection<Car> cars;

        public Parking(string type, int capacity)
        {
            this.cars = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.cars.Count;

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                this.cars.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (this.Count == 0)
            {
                return null;
            }

            Car car = this.cars.OrderByDescending(c => c.Year).First();

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.cars)
            {
                sb.AppendLine(car.ToString());
            }
                

            return sb.ToString().TrimEnd();
        }
    }
}
