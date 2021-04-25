using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Program Files (x86)\Microsoft Help Viewer\v2.3 ";

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            FileInfo[] fileInfos = directoryInfo.GetFiles();

            Dictionary<string, Dictionary<string, double>> fullInfo =
                                        new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in fileInfos)
            {
                if (!fullInfo.ContainsKey(item.Extension))
                {
                    fullInfo[item.Extension] = new Dictionary<string, double>();
                }

                fullInfo[item.Extension].Add(item.Name, item.Length);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in fullInfo.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                sb.AppendLine(kvp.Key);

                foreach (var item in kvp.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{item.Key} - {item.Value / 1024:f3}kb");
                }
            }

            File.WriteAllText("../../../report.txt", sb.ToString().TrimEnd());
        }
    }
}
