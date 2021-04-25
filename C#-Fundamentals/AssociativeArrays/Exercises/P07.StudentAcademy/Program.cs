using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }

                studentsGrades[name].Add(grade);
            }

            studentsGrades = studentsGrades
                .Where(s => s.Value.Average() >= 4.50)
                .OrderByDescending(s => s.Value.Average())
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in studentsGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
