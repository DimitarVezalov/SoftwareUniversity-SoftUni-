using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            DrinkType drinkType;
            bool isParsed = Enum.TryParse<DrinkType>(type, out drinkType);

            IDrink drink = null;

            if (isParsed)
            {
                if (drinkType == DrinkType.Tea)
                {
                    drink = new Tea(name, portion, brand);
                }
                else if (drinkType == DrinkType.Water)
                {
                    drink = new Water(name, portion, brand);
                }
            }

            if (drink == null)
            {
                return null;
            }

            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);

        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFoodType foodType;
            bool isParsed = Enum.TryParse<BakedFoodType>(type, out foodType);

            IBakedFood food = null;

            if (isParsed)
            {
                if (foodType == BakedFoodType.Bread)
                {
                    food = new Bread(name, price);
                }
                else if (foodType == BakedFoodType.Cake)
                {
                    food = new Cake(name, price);
                }
            }

            if (food == null)
            {
                return null;
            }

            this.bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, food.Name, foodType.ToString());
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            TableType tableType;
            bool isParsed = Enum.TryParse<TableType>(type, out tableType);

            ITable table = null;

            if (isParsed)
            {
                if (tableType == TableType.InsideTable)
                {
                    table = new InsideTable(tableNumber, capacity);
                }
                else if (tableType == TableType.OutsideTable)
                {
                    table = new OutsideTable(tableNumber, capacity);
                }
            }

            if (table == null)
            {
                return null;
            }

            this.tables.Add(table);

            return String.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            this.tables
                .Where(t => !t.IsReserved)
                .ToList()
                .ForEach(t => sb.AppendLine(t.GetFreeTableInfo()));

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, this.totalIncome);
           
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            var bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            string output = $"Table: {tableNumber}\r\n" +
                             $"Bill: {bill:f2}";

            return output;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables
            .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks
                .FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = this.bakedFoods
                .FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables
                .FirstOrDefault(t => t.Capacity >= numberOfPeople && t.IsReserved == false);

            if (table == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
