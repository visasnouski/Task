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
                                                   // Dictionary<string, City> allcityDI = new Dictionary<string, City>();
            ReaderStart reader = new ReaderStart(new FromFIleDI()); //Чтение из файла;
            Parallel.For(0, files.Length, new ParallelOptions { MaxDegreeOfParallelism = N },  //Обработка файлов производится параллельно, максимум N файлов одновременно
                i =>
               {
                   reader.ReadGet(files[i], ref allcity);
               });

            WriterStart write = new WriterStart(new WriterDI());
            write.WriteData(allcity, "output.txt");
           // Writer.Write(allcity, ); //Сохранение списка allcity в файл
        }



    }
}
