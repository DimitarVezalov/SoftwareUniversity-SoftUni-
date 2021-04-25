using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArr = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsArr = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();    

            int targetTask = int.Parse(Console.ReadLine());
            int threadValue = 0;
            Stack<int> tasks = new Stack<int>(tasksArr);
            Queue<int> threads = new Queue<int>(threadsArr);

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == targetTask)
                {
                    threadValue = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threadValue} killed task {targetTask}");

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
