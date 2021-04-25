using System;
using System.Collections.Generic;

namespace P05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();


            string content = Console.ReadLine();

            List<string> comments = new List<string>();

            while (true)
            {
                string comment = Console.ReadLine();

                if (comment == "end of comments")
                {
                    break;
                }

                comments.Add(comment);

            }

            Console.WriteLine($"<h1>\n\t{title}\n</h1>");
            Console.WriteLine($"<article>\n\t{content}\n</article>");
            foreach (var comment in comments)
            {
                Console.WriteLine($"<div>\n\t{comment}\n</div>");
            }
        }
    }
}
