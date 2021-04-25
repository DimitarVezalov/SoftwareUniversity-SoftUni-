using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private const string DefaultEfficiency = "n/a";

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = DefaultEfficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model,power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
             : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string displString = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();

            sb.
                AppendLine($"{this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displString}")
                .AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
