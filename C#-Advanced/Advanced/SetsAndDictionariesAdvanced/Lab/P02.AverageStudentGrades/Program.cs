using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] studentArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = studentArgs[0];
                decimal grade = decimal.Parse(studentArgs[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<decimal>();
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var kvp in studentsGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ",kvp.Value.Select(x => x.ToString("f2")))}" +
                                                    $" (avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
