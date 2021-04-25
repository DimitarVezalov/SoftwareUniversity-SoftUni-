
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasterRaces.IO.Contracts
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            File.WriteAllText("../../../output.txt", message);
        }
    }
}
