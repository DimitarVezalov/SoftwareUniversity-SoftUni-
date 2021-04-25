using System;
using System.IO;
using System.Linq;

namespace P04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../copyMe.png";
            string outputPath = "../../../newImage.png";

            using FileStream reader = new FileStream(path, FileMode.Open);
            using FileStream writer = new FileStream(outputPath, FileMode.OpenOrCreate);

            while (true)
            {
                byte[] buffer = new byte[4096];
                int count = reader.Read(buffer, 0, buffer.Length);

                if (count == 0)
                {
                    break;
                }

                writer.Write(buffer);
            }
        }
    }
}
