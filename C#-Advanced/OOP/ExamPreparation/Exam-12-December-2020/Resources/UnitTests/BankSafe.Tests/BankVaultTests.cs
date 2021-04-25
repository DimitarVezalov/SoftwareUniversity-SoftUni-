using NUnit.Framework;
using System;


namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            int expCellsCount = 12;

            Assert.AreEqual(expCellsCount, this.bankVault.VaultCells.Count);
        }

        [Test]
        public void AddItemShouldThrowExceptionWithNonExistingCellName()
        {
            string cellName = "Z1";
            Item item = new Item("Pesho", "111");

            Assert.That(() =>
            {
                this.bankVault.AddItem(cellName, item);

            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void AddItemShouldThrowExceptionWithCellAlreadyTaken()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            this.bankVault.AddItem(cellName, item);

            Assert.That(() =>
            {
                this.bankVault.AddItem(cellName, new Item("Gosho", "222"));

            }, Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void AddItemShouldThrowExceptionWithCellExistingItem()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            this.bankVault.AddItem(cellName, item);

            Assert.That(() =>
            {
                this.bankVault.AddItem("A2", item);

            }, Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }


        [Test]
        public void AddItemShouldReturnCorrectString()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            string expOutput = $"Item:{item.ItemId} saved successfully!";

            string actualOutput = this.bankVault.AddItem(cellName, item);

            Assert.AreEqual(expOutput, actualOutput);
        }

        [Test]
        public void RemoveShouldThrowExceptionWithNonExistingCell()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            this.bankVault.AddItem(cellName, item);

            Assert.That(() =>
            {
                this.bankVault.RemoveItem("Z1", item);
                
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void RemoveShouldThrowExceptionWithDifferentItem()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");
            Item item2 = new Item("Gosho", "222");


            this.bankVault.AddItem(cellName, item);

            Assert.That(() =>
            {
                this.bankVault.RemoveItem(cellName, item2);

            }, Throws.ArgumentException.With.Message.EqualTo("Item in that cell doesn't exists!"));
        }

        [Test]
        public void RemoveShouldSetCellValueToNull()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            this.bankVault.AddItem(cellName, item);

            this.bankVault.RemoveItem(cellName, item);

            Assert.IsNull(this.bankVault.VaultCells[cellName]);

        }

        [Test]
        public void RemoveShouldReturnCorrectString()
        {
            string cellName = "A1";
            Item item = new Item("Pesho", "111");

            this.bankVault.AddItem(cellName, item);

            string expOutput = $"Remove item:{item.ItemId} successfully!";
            string actualOutput = this.bankVault.RemoveItem(cellName, item);

            Assert.AreEqual(expOutput, actualOutput);
           
        }
    }
}