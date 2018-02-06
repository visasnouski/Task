using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   static class Compares
    {
        public static void Compare(ref List<City> allcity, City city)
        {
            bool overlap = false;
            lock (allcity)
            {
                foreach (City one in allcity)
                {
                    if (String.Compare(one.Name, city.Name, true) == 0)
                    {
                        one.Addpopulation(city.Population);
                        overlap = true;
                        break;
                    }
                }
                if (!overlap)
                {
                    if (city.Name!=null)
                    {
                        allcity.Add(city);
                    }
                }
            }
        }
    }
}
