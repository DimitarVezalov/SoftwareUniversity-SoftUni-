using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < count; i++)
            {
                string[] pieceArgs = Console.ReadLine()
                    .Split('|',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = pieceArgs[0];
                string composer = pieceArgs[1];
                string key = pieceArgs[2];

                Piece piece = new Piece(name, composer, key);

                pieces.Add(piece);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                string pieceName = cmdArgs[1];

                if (type == "Add")
                {
                    if (pieces.Any(p => p.Name == pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                        continue;
                    }

                    string pieceComposer = cmdArgs[2];
                    string pieceKey = cmdArgs[3];

                    Piece piece = new Piece(pieceName, pieceComposer, pieceKey);
                    pieces.Add(piece);

                    Console.WriteLine($"{pieceName} by {pieceComposer} in {pieceKey} added to the collection!");
                }
                else if (type == "Remove")
                {                    
                    if (!pieces.Any(p => p.Name == pieceName))
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        continue;
                    }

                    Piece piece = pieces.FirstOrDefault(p => p.Name == pieceName);

                    pieces.Remove(piece);

                    Console.WriteLine($"Successfully removed {pieceName}!");

                }
                else if (type == "ChangeKey")
                {
                    if (!pieces.Any(p => p.Name == pieceName))
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        continue;
                    }

                    string newKey = cmdArgs[2];

                    Piece piece = pieces.FirstOrDefault(p => p.Name == pieceName);
                    piece.Key = newKey;

                    Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                }
            }

            foreach (var piece in pieces.OrderBy(p => p.Name).ThenBy(p => p.Composer))
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }
}
