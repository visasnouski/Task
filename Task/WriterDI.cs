using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
    class WriterDI :IWriterDI
    {
        /// <summary>
        /// Метод сохраняет список городов allcity в файл filename
        /// </summary>
        /// <param name="allcity">Список городов</param>
        /// <param name="filename">Имя файла</param>
        public void Write(List<City> allcity, string filename)
        {
            Console.WriteLine("Запись в файл output.txt");
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
