using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckComputerId(computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            ComponentType componentEnum;
            bool isParsed = Enum.TryParse<ComponentType>(componentType, out componentEnum);

            if (!isParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            IComponent component = null;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            computer.AddComponent(component);
            this.components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }


        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            ComputerType computerEnum;
            bool isParsed = Enum.TryParse<ComputerType>(computerType, out computerEnum);

            if (!isParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;

            if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            this.computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            this.CheckComputerId(computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            PeripheralType peripheralEnum;
            bool isParsed = Enum.TryParse<PeripheralType>(peripheralType, out peripheralEnum);

            if (!isParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            IPeripheral peripheral = null;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId); 
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any())
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer computer = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString().TrimEnd();

        }

        public string BuyComputer(int id)
        {
            this.CheckComputerId(id);

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);

            return computer.ToString().TrimEnd();
        }

        public string GetComputerData(int id)
        {
            this.CheckComputerId(id);

            return this.computers.FirstOrDefault(c => c.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.CheckComputerId(computerId);

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            computer.RemoveComponent(componentType);

            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.CheckComputerId(computerId);

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.RemovePeripheral(peripheralType);

            IPeripheral peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void CheckComputerId(int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
