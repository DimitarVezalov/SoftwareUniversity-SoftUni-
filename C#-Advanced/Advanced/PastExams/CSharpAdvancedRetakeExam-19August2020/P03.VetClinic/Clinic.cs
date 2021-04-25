using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly ICollection<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.pets.Count;

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.pets.FirstOrDefault(p => p.Name == name);

            if (pet != null)
            {
                this.pets.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.pets
                .FirstOrDefault(p => p.Age == this.pets.Select(p => p.Age).Max());

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine("The clinic has the following patients:");

            foreach (var pet in this.pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
