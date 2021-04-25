using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private const string DefaultColor = "n/a";

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = DefaultColor;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string weightString = this.Weight == 0 ? "n/a" : this.Weight.ToString();

            sb
                .AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine.ToString()}")
                .AppendLine($"  Weight: {weightString}")
                .AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
