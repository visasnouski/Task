using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   public class City
    {
        private string name;
        private int population;
       

        public string Name { get { return name; } }
        public int Population { get { return population; } }
        public City(string line)
        {
            try
            {
                int lenght = SplitCity.Count(line);
                if (lenght == 2)
                {

                    this.name = SplitCity.GetName(line);
                    this.population = SplitCity.GetPopulation(line);
                }
                else
                { Console.WriteLine("Неверный формат строк в файле" + line); }
            }
            catch {
                Console.WriteLine("Неверный формат строк в файле "+line);
            }
        }
        public void Addpopulation(int count)
        {
            this.population += count;
        }

        public override string ToString()
        {
            return name.ToString()+","+ Population+ Environment.NewLine;
        }
    }
}
