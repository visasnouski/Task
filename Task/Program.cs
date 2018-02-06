using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.IO;

namespace Task
{
    public class Program
    {

        public static void Main(string[] args)
        {
            if (args.Length >= 1 && Directory.Exists(args[0]))
            {
                string[] files = Directory.GetFiles(args[0]);
                Start(files);
            }
            else
                Console.WriteLine("Папка не найдена");
        }

        public static void Start(string[] files)
        {
            int N = Convert.ToInt32(ConfigurationSettings.AppSettings["N"]);
            List<City> allcity = new List<City>(); //Список городов
                                                                
            Parallel.For(0, files.Length, new ParallelOptions { MaxDegreeOfParallelism = N },  //Обработка файлов производится параллельно, максимум N файлов одновременно
                i =>
                {
                    Reader.GetAllCityFromFile(files[i], ref allcity);
                });

            Console.WriteLine("Запись в файл output.txt");

            Writer.Write(allcity, "output.txt"); //Сохранение списка allcity в файл
        }



    }
}
