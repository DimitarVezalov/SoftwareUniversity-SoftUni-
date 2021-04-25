using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string type, string[] args)
        {
            Animal animal = null;

            string name = args[0];
            int age = int.Parse(args[1]);
            string gender = args[2];

            switch (type)
            {
                case "Dog":
                    animal = new Dog(name, age, gender);
                    break;
                case "Cat":
                    animal = new Cat(name, age, gender);
                    break;
                case "Frog":
                    animal = new Frog(name, age, gender);
                    break;
                case "Kitten":
                    animal = new Kitten(name, age);
                    break;
                case "Tomcat":
                    animal = new Tomcat(name, age);
                    break;
            }

            return animal;
        }
    }
}
