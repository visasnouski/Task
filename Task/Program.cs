using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.IO;

namespace Task
{
    public static class Program
    {
        public static string path;
        public static void Main(string[] args)
        {
            path = args[0];
            DataSourceStart _source = new DataSourceStart(new DataSourceDI());
            IEnumerable<string> listEnum = _source.GetData();
            ParserStart _parse = new ParserStart(new ParserDI());
            Dictionary<string, int> allCity = _parse.GetData(listEnum);
            WriterStart write = new WriterStart(new WriterDI());
            write.WriteData(allCity, "output.txt");

        }
    }
}
