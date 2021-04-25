using CollectionHierarchy.Models;
using System;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int removeOperations = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();

            foreach (var item in items)
            {
                sb1.Append($"{addCollection.Add(item)} ");
                sb2.Append($"{addRemoveCollection.Add(item)} ");
                sb3.Append($"{myList.Add(item)} ");
            }

            Console.WriteLine($"{sb1.ToString().TrimEnd()}\n{sb2.ToString().TrimEnd()}\n{sb3.ToString().TrimEnd()}");

            StringBuilder sbRemoved1 = new StringBuilder();
            StringBuilder sbRemoved2 = new StringBuilder();

            for (int i = 0; i < removeOperations; i++)
            {
                sbRemoved1.Append($"{addRemoveCollection.Remove()} ");
                sbRemoved2.Append($"{myList.Remove()} ");
            }

            Console.WriteLine($"{sbRemoved1.ToString().TrimEnd()}\n{sbRemoved2.ToString().TrimEnd()}");
        }
    }
}
