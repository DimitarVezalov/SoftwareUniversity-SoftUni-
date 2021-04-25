using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model,
                                decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance => this.components.Count == 0 ? base.OverallPerformance
            : base.OverallPerformance + this.components.Average(c => c.OverallPerformance);

        public override decimal Price => base.Price + this.components.Sum(c => c.Price) +
            this.peripherals.Sum(p => p.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any() || !this.components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any() || !this.peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var comp in this.components)
            {
                sb.AppendLine($"  {comp.ToString()}");
            }

            string peripheralPerf = this.peripherals.Any()
                ? $"{this.peripherals.Average(p => p.OverallPerformance):f2}" : $"{0:f2}"; 

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); " +
                $"Average Overall Performance ({peripheralPerf}):");
            
            foreach (var per in this.peripherals)
            {
                sb.AppendLine($"  {per.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
