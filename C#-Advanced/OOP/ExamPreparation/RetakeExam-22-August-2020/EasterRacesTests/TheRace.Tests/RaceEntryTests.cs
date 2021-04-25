using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private const int MIN_PARTICIPANTS = 2;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.IsNotNull(raceEntry);
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldThrowExceptionWithNullParameter()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = null;

            Assert.That(() =>
            {
                raceEntry.AddDriver(driver);

            },Throws.InvalidOperationException.With.Message.EqualTo("Driver cannot be null."));

        }

        [Test]
        public void AddDriverShouldThrowExceptionWithExistingDriver()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("Golf", 100, 1500);
            UnitDriver driver = new UnitDriver("Pesho", car);
            raceEntry.AddDriver(driver);

            Assert.That(() =>
            {
                raceEntry.AddDriver(driver);

            }, Throws.InvalidOperationException.With.Message.EqualTo($"Driver {driver.Name} is already added."));

        }

        [Test]
        public void AddDriverShouldIncreaseCount()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("Golf", 100, 1500);
            UnitDriver driver = new UnitDriver("Pesho", car);
            raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);

        }

        [Test]
        public void AddDriverShouldReturnCorrectMessage()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("Golf", 100, 1500);
            UnitDriver driver = new UnitDriver("Pesho", car);

            string expMessage = $"Driver {driver.Name} added in race.";
            string actualMessage = raceEntry.AddDriver(driver);

            Assert.AreEqual(expMessage, actualMessage);

        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWithNotEnoughDrivers()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("Golf", 100, 1500);
            UnitDriver driver = new UnitDriver("Pesho", car);
            raceEntry.AddDriver(driver);

            Assert.That(() =>
            {
                raceEntry.CalculateAverageHorsePower();

            }, Throws.InvalidOperationException.With.Message
            .EqualTo($"The race cannot start with less than {MIN_PARTICIPANTS} participants."));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectResult()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("Golf", 100, 1500);
            UnitDriver driver = new UnitDriver("Pesho", car);

            UnitCar car2 = new UnitCar("BMW", 100, 2500);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);

            double expResult = 100;
            double actualResult = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expResult, actualResult);
        }
    }
}