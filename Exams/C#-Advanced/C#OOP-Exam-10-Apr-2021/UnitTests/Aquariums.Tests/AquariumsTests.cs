namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private string fishName = "Nemo";

        private Aquarium aquarium;
        private string aquariumName = "SaltWater";
        private int capacity = 5;

        [SetUp]
        public void SetUp()
        {
            this.fish = new Fish(this.fishName);

            this.aquarium = new Aquarium(aquariumName, capacity);
        }

        [Test]
        public void TestIfFishConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.fishName, this.fish.Name);
            Assert.IsTrue(this.fish.Available);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumConstructorShouldThrowExceptionWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, this.capacity);

            }, "Invalid aquarium name!");
        }

        [Test]
        public void AquariumConstructorShouldThrowExceptionWithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium(this.aquariumName, -1);

            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void TestIfAquariumConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.aquariumName, this.aquarium.Name);
            Assert.AreEqual(this.capacity, this.aquarium.Capacity);
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWithNotEnoughCapacity()
        {
            Aquarium aquarium1 = new Aquarium("Freshwater", 2);

            aquarium1.Add(new Fish("pesho"));
            aquarium1.Add(new Fish("gosho"));

            Assert.Throws<InvalidOperationException>(() => 
            {

                aquarium1.Add(new Fish("misho"));

            }, "Aquarium is full!");
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.aquarium.Add(this.fish);

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWitNonExistingFish()
        {
            this.aquarium.Add(this.fish);

            string name = "Pesho";

            Assert.Throws<InvalidOperationException>(() => 
            {

                this.aquarium.RemoveFish(name);
            
            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.Add(new Fish("Pesho"));

            this.aquarium.RemoveFish("Pesho");

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void SellFishShouldThrowExceptionWithNonExistingFish()
        {
            this.aquarium.Add(this.fish);

            string name = "Pesho";

            Assert.Throws<InvalidOperationException>(() => 
            {

                this.aquarium.SellFish(name);
            
            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void SellFishSetsFishAvailabilityToFalse()
        {
            this.aquarium.Add(this.fish);

            this.aquarium.SellFish(this.fishName);

            Assert.IsFalse(this.fish.Available);
        }

        [Test]
        public void SellFishShouldReturnCorrectFish()
        {
            this.aquarium.Add(this.fish);

            var requestedFish = this.aquarium.SellFish(this.fishName);

            Assert.AreSame(this.fish, requestedFish);
        }

        [Test]
        public void ReportShouldReturnCorrectOutput()
        {
            Fish fish1 = new Fish("Pesho");
            Fish fish2 = new Fish("Gosho");

            this.aquarium.Add(this.fish);
            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);

            string fishNames = "Nemo, Pesho, Gosho";

            string expectedOutput = $"Fish available at {this.aquariumName}: {fishNames}";

            string actualOutput = this.aquarium.Report();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
