using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
    class WriterDI : IWriterDI
    {
        public void Write(Dictionary<string, int> allcity, string filename)
        {
            Console.WriteLine("Запись в файл output.txt");
            File.WriteAllLines(filename, allcity.Select(kvp => string.Format("{0},{1}", kvp.Key, kvp.Value)),Encoding.UTF8);
        }
    }
}
