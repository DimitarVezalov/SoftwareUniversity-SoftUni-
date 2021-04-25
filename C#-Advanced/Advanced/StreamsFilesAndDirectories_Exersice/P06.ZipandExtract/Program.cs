using System;
using System.IO.Compression;

namespace P06.ZipandExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("../../../myZip.zip", ZipArchiveMode.Create);

            ZipArchiveEntry zipArchiveEntry =
                    zipFile.CreateEntryFromFile("../../../../Resources/copyMe.png", "newImage.png");
        }
    }
}
