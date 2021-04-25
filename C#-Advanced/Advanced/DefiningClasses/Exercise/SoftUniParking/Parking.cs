using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

        public int Capacity { get; private set; }

        public int Count => this.Cars.Count;

        public string AddCar(Car Car)
        {
            string regNumber = Car.RegistrationNumber;

            if (this.Cars.Any(c => c.RegistrationNumber == regNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Count == this.Capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(Car);

            return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

            this.Cars.Remove(car);

            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

            if (car == null)
            {
                return null;
            }

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {

                this.RemoveCar(number);
                //Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == number);

                //if (car != null)
                //{
                //    this.Cars.Remove(car);
                //}
            }
        }
    }
}
