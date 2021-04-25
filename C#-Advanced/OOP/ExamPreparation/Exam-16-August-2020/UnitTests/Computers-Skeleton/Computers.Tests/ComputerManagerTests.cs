using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private string manufacturer = "Asus";
        private string model = "Tuf";
        private decimal price = 1000;

        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer(manufacturer, model, price);

            this.computerManager = new ComputerManager();
        }

        [Test]
        public void TestComputerConstructor()
        {
            Assert.IsNotNull(this.computer);
            Assert.AreEqual(this.manufacturer, this.computer.Manufacturer);
            Assert.AreEqual(this.model, this.computer.Model);
            Assert.AreEqual(this.price, this.computer.Price);
        }

        [Test]
        public void TestComputerManagerConstructor()
        {
            Assert.IsNotNull(this.computerManager);
            Assert.IsNotNull(this.computerManager.Computers);
            Assert.AreEqual(0, this.computerManager.Count);
            Assert.That(this.computerManager.Computers, Is.Empty);
        }

        [Test]
        public void TestCountProperty()
        {
            this.computerManager.AddComputer(computer);
            Assert.AreEqual(1, this.computerManager.Count);
        }

        [Test]
        public void AddComputerShouldThrowExceptionWithNullComputer()
        {
            Computer computer = null;

            Assert.Throws<ArgumentNullException>(() => 
            {
                this.computerManager.AddComputer(computer);

            }, "Can not be null!");
        }

        [Test]
        public void AddComputerShouldThrowExceptionWithExistingComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Computer computer2 = new Computer(manufacturer, model, 2000);

            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.AddComputer(computer2);

            }, "This computer already exists.");
        }

        [Test]
        public void AddComputerShouldPhysicalyAddComputerAndIncreaseCount()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.That(this.computerManager.Computers, Has.Member(this.computer));
            Assert.AreEqual(1, this.computerManager.Count);
        }

        [Test]
        public void RemoveComputerShouldReturnCorrectComputerAndDecreaseCount()
        {
            this.computerManager.AddComputer(this.computer);

            Computer returned = this.computerManager.RemoveComputer(manufacturer, model);

            Assert.AreSame(this.computer, returned);
            Assert.AreEqual(0, this.computerManager.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWithNullManufacturer()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => 
            {
                this.computerManager.RemoveComputer(null, this.model);
            }, "Can not be null!");
        }

        [Test]
        public void RemoveShouldThrowExceptionWithNullModel()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.RemoveComputer(this.manufacturer, null);
            }, "Can not be null!");
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullManufacturer()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {

                this.computerManager.GetComputer(null, model);

            }, "Can not be null!");
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullModel()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {

                this.computerManager.GetComputer(manufacturer, null);

            }, "Can not be null!");
        }


        [Test]
        public void GetComputerShouldThrowExceptionWithNonExistingComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.GetComputer("Acer", "Helios");

            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldReturnCorrectComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Computer returned = this.computerManager.GetComputer(this.manufacturer, this.model);

            Assert.AreSame(this.computer, returned);
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowExceptionWithNullManufacturer()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => 
            {
                this.computerManager.GetComputersByManufacturer(null);

            }, "Can not be null!");
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnCorrectCollection()
        {
            List<Computer> expComputers = new List<Computer>();

            Computer computer1 = new Computer(this.manufacturer, this.model + "1", 2000);
            Computer computer2 = new Computer(this.manufacturer, this.model + "2", 3000);
            Computer computer3 = new Computer(this.manufacturer + "1", this.model + "3", 4000);

            expComputers.Add(this.computer);
            expComputers.Add(computer1);
            expComputers.Add(computer2);

            this.computerManager.AddComputer(this.computer);
            this.computerManager.AddComputer(computer1);
            this.computerManager.AddComputer(computer2);
            this.computerManager.AddComputer(computer3);

            var filtered = this.computerManager.GetComputersByManufacturer(this.manufacturer);

            CollectionAssert.AreEqual(expComputers, filtered);
            Assert.AreEqual(3, filtered.Count);
        }

        [Test]
        public void GetAllByManufacturerShouldReturnZeroWithNoMatches()
        {
            var collection = this.computerManager.GetComputersByManufacturer("Mac");

            Assert.That(collection.Count, Is.EqualTo(0));
        }
    }
}