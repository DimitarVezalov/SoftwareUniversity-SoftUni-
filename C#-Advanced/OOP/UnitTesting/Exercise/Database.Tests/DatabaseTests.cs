using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(5, 2, 4, 2, 6);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 5;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FetchShouldReturnCorrectArray()
        {
            int[] expectedArr = { 5, 2, 4, 2, 6 };
            int[] fetchedArr = this.database.Fetch();

            CollectionAssert.AreEqual(expectedArr, fetchedArr);

        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            int expectedCount = 6;

            this.database.Add(10);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void AddShouldPhysicaliAddElementAtTheEndOFTheCollection()
        {
            int element = 10;

            this.database.Add(element);
            int[] fetched = this.database.Fetch();

            Assert.AreEqual(element, fetched[fetched.Length - 1]);
        }

        [Test]
        public void AddShouldThrowExceptionIfFullCappacity()
        {
            for (int i = 0; i < 11; i++)
            {
                this.database.Add(i);
            }

            Assert.That(() =>
            {
                this.database.Add(15);

            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            int expectedCount = 4;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfEmptyCollection()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Remove();
            }

            Assert.That(() =>
            {
                this.database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }
    }
}