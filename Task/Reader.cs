using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.IO;
using System.Net;

namespace Task
{
    static class Reader
    {
        public static void GetAllCityFromFile(string filepath, ref List<City> allcity)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath, Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Compares.Compare(ref allcity, new City(line));
                        //Console.WriteLine(filepath + line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(filepath+ " "+ ex.Message);
            }
        }

        public static void GetAllCityFromWeb(string url, ref List<City> allcity)
        {
            try
            {
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Compares.Compare(ref allcity, new City(line));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(url + " " + ex.Message);
            }
        }

      
    }
}
