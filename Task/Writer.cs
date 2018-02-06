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
        /// <summary>
        /// Метод сохраняет список городов allcity в файл filename
        /// </summary>
        /// <param name="allcity">Список городов</param>
        /// <param name="filename">Имя файла</param>
        public static void Write(List<City> allcity, string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                foreach (City one in allcity)
                    File.AppendAllText(filename, one.ToString(), Encoding.UTF8);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
