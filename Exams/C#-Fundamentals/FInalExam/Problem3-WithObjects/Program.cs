using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    public class Guest
    {
        public Guest(string name)
        {
            this.Name = name;
            this.Meals = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Meals { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {string.Join(", ", this.Meals)}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Guest> guests = new List<Guest>();

            int unlikedMeals = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string guestName = cmdArgs[1];
                string meal = cmdArgs[2];

                if (cmdType == "Like")
                {                               
                    
                    if (!guests.Any(g => g.Name == guestName))
                    {
                        Guest guest = new Guest(guestName);

                        guests.Add(guest);
                        guest.Meals.Add(meal);

                    }
                    else
                    {
                        Guest currGuest = guests.FirstOrDefault(g => g.Name == guestName);

                        if (!currGuest.Meals.Contains(meal))
                        {
                            currGuest.Meals.Add(meal);
                        } 
                    
                        
                    }

                }
                else if (cmdType == "Unlike")
                { 

                    if (!guests.Any(g => g.Name == guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else
                    {
                        Guest currentGuest = guests.FirstOrDefault(g => g.Name == guestName);

                        if (!currentGuest.Meals.Contains(meal))
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            currentGuest.Meals.Remove(meal);
                            unlikedMeals++;

                            Console.WriteLine($"{guestName} doesn't like the {meal}.");
                        }
                    }
                    
                }

            }

            guests = guests
                .OrderByDescending(g => g.Meals.Count)
                .ThenBy(g => g.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, guests));
            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
