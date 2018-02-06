using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    static class SplitCity
    {
        /// <summary>
        /// Метод извлекает количество объектов из строки разделенных символом ','
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static int Count(string line)
        {
            return line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        /// <summary>
        /// Метод извлекает численность населения из строки line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static int GetPopulation(string line)
        {
            return Convert.ToInt32(line.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
        }
        /// <summary>
        /// Метод извлекает имя города из строки line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetName (string line)
        {
          return  line.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
       
    }
}
