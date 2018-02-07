using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class CompareDI: ICompare
    {
        public  void Compare(ref List<City> allcity, City city)
        {
            BinarySearchAndInsert bsCity = new BinarySearchAndInsert();
            lock (allcity)
            {
                if (city.Name != null)
                {
                    if (allcity.Count != 0)
                    {
                        SearchAndInsert(ref allcity, city, bsCity);
                    }
                    else
                        allcity.Add(city);
                }
            }
        }

        private void SearchAndInsert(ref List<City> allcity, City one, BinarySearchAndInsert dc)
        {
            int index = allcity.BinarySearch(one, dc);
            if (index < 0)
            {
                allcity.Insert(~index, one);
            }
            if (index >= 0)
            {
                allcity[index].Addpopulation(one.Population);
            }
        }
    }
}
