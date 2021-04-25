using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Animals.Birds;
using P04.WildFarm.Models.Animals.Mammals;
using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
