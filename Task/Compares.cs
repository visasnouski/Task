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
        /// Метод поиска одинаковых городов и суммирования их численности населения если есть совпадение, иначе новый город добавляется в список городов
        /// </summary>
        /// <param name="allcity">Cписок городов</param>
        /// <param name="city">Один город</param>
        public static void Compare(ref List<City> allcity, City city)
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

        public static void Update(StreamReader reader,ref List<City> allcity)
        {
            using (StreamReader rd =reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Compares.Compare(ref allcity, new City(line));  //Суммирование численности или добавление в список нового города
                }
            }
        }
    }
}
