using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(5, 6);
            Shape circle = new Circle(7);

            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());

            Console.WriteLine("------------------------------------");

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            Console.WriteLine("-------------------------------------");

            Console.WriteLine(rect.Draw());
            Console.WriteLine(circle.Draw());

        }
    }
}
