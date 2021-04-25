using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesInfo = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] courseArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string course = courseArgs[0];
                string name = courseArgs[1];

                if (!coursesInfo.ContainsKey(course))
                {
                    coursesInfo[course] = new List<string>();
                }

                if (!coursesInfo[course].Contains(name))
                {
                    coursesInfo[course].Add(name);
                }
            }

            foreach (var kvp in coursesInfo.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
