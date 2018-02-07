using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
    class Compares
    {
       public static void Update(StreamReader reader,ref List<City> allcity)
        {
            CompareStart _compare = new CompareStart(new CompareDI());
            using (StreamReader rd =reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _compare.Comare(ref allcity, new City(line));  //Для больших файлов 
                 // Compares.CompareCompareBinaryForSmallFile(ref allcity, new City(line));  //Для маленьких файлов
                }
            }
        }
    }
}
