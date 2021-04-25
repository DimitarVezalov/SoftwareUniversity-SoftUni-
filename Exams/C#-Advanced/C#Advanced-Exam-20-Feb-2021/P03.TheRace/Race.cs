using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.racers.Count;

        public void Add(Racer Racer)
        {
            if (this.Count < this.Capacity)
            {
                this.racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = this.racers.FirstOrDefault(r => r.Name == name);

            if (racer == null)
            {
                return false;
            }

            this.racers.Remove(racer);

            return true;
        }

        public Racer GetOldestRacer()
        {
            return this.racers.FirstOrDefault(r => r.Age == this.racers.Select(x => x.Age).Max()); 
        }

        public Racer GetRacer(string name)
        {
            return this.racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return this.racers
                .FirstOrDefault(r => r.Car.Speed == this.racers.Select(x => x.Car.Speed).Max());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
