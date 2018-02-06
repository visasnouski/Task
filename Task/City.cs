﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   public class City
    {
        private string name; //Имя города
        private int population; //Численность населения
        private string key;

        public string Name { get { return name;}}
        public int Population { get { return population;}}
        public City(string line) //Конструктор
        {
            try
            {
                int lenght = SplitCity.Count(line); //Размер массива после разделения строки символом ','
                if (lenght == 2)
                {
                    this.name = SplitCity.GetName(line); //Получить имя города из строки
                    this.population = SplitCity.GetPopulation(line);// Получить численность населения из строки
                    this.key = this.name.Remove(2);
                }
                else
                { Console.WriteLine("Неверный формат строк в файле" + line); }
            }
            catch {
                Console.WriteLine("Неверный формат строк в файле "+line);
            }
        }
        /// <summary>
        /// Суммировать численность населения
        /// </summary>
        /// <param name="count"></param>
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
