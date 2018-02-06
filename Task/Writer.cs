using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
   static class Writer
    {
        public static void Write(List<City> allcity, string filename)
        {
            if (File.Exists(filename))
            {
              File.Delete(filename);
            }
            foreach (City one in allcity)
           File.AppendAllText(filename, one.ToString(),Encoding.UTF8);
        }
    }
}
