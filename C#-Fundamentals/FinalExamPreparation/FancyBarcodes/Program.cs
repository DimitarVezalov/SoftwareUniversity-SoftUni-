using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^\@\#+(?<barcode>[A-Z][A-Za-z\d]{4,}[A-Z])\@\#+$");

            Regex split = new Regex(@"[a-zA-Z]");

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Match match = regex.Match(Console.ReadLine());

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;

                    string[] group = split.Split(barcode).Where(x => x != "").ToArray();

                    string resultGroup = group.Length == 0 ? "00" : string.Join("", group);

                    Console.WriteLine($"Product group: {resultGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
