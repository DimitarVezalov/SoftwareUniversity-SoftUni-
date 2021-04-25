using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var songsArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var songs = new Queue<string>(songsArr);

            while (songs.Any())
            {
                var cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var cmdType = cmdArgs[0];

                if (cmdType == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmdType == "Add")
                {
                    var song = string.Join(" ", cmdArgs.Skip(1));

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}