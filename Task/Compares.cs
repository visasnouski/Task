using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
   static class Compares
    {
        /// <summary>
        /// Метод поиска для маленьких данных одинаковых городов и суммирования их численности населения если есть совпадение, иначе новый город добавляется в список городов
        /// </summary>
        /// <param name="allcity">Cписок городов</param>
        /// <param name="city">Один город</param>
        private static void CompareCompareBinaryForSmallFile(ref List<City> allcity, City city)
        {
            bool overlap = false;
            lock (allcity)
            {
                foreach (City one in allcity)
                {
                    if (String.Compare(one.Name, city.Name, true) == 0)
                    {
                        one.Addpopulation(city.Population); //Суммирования численности населения одинаковых городов
                        overlap = true;
                        break;
                    }
                }
                if (!overlap)
                {
                    if (city.Name!=null)
                    {
                        
                        allcity.Add(city);// Добавление нового города в список городов
                       
                    }
                }
            }
        }

        private static void SearchAndInsert(ref List<City> allcity,City one, BinarySearchAndInsert dc)
        {
            //Console.WriteLine("\nBinarySearch and Insert \"{0}\":", one);

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
        /// <summary>
        /// Метод поиска для больших данных одинаковых городов и суммирования их численности населения если есть совпадение, иначе новый город добавляется в список городов
        /// </summary>
        /// <param name="allcity">Cписок городов</param>
        /// <param name="city">Один город</param>
        private static void CompareBinaryForBigFile(ref List<City> allcity, City city)
        {
            bool overlap = false;
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

        public static void Update(StreamReader reader,ref List<City> allcity)
        {
            using (StreamReader rd =reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Compares.CompareBinaryForBigFile(ref allcity, new City(line));  //Для больших файлов 
                   // Compares.Compare(ref allcity, new City(line));  //Для маленьких файлов
                }
            }
        }
    }
}
