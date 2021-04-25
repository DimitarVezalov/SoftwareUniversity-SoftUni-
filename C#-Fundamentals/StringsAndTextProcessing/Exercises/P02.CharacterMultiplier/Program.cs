using System;

namespace P02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

            string firstWord = words[0];
            string secondWord = words[1];

            int count = Math.Min(firstWord.Length, secondWord.Length);
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += firstWord[i] * secondWord[i];

            }

            if (firstWord.Length != secondWord.Length)
            {
                string addition = firstWord.Length > secondWord.Length ? firstWord : secondWord;

                addition = addition.Substring(count);

                for (int i = 0; i < addition.Length; i++)
                {
                    sum += addition[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
