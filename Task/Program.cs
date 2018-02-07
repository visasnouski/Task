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
    public static class Program
    {
        public static string path;
        public static void Main(string[] args)
        {
            path = @"f:\testtask\base\";
            DataSourceStart _source = new DataSourceStart(new DataSourceDI());
            IEnumerable<string> listEnum = _source.GetData();

           
            // var singleString = string.Join(Environment.NewLine, listEnum.ToArray());

            ParserStart _parse = new ParserStart(new ParserDI());
            Dictionary< string, int> allCity = _parse.GetData(listEnum);

            WriterStart write = new WriterStart(new WriterDI());
            write.WriteData(allCity, "output.txt");

        }

        public static void Start(string[] files)
        {
           
            //Сохранение списка allcity в файл
            //int N = Convert.ToInt32(ConfigurationSettings.AppSettings["N"]);
            //List<City> allcity = new List<City>(); //Список городов
            //ReaderStart reader = new ReaderStart(new FromFIleDI()); //Чтение из файла;
            //Parallel.For(0, files.Length, new ParallelOptions { MaxDegreeOfParallelism = N },  //Обработка файлов производится параллельно, максимум N файлов одновременно
            //    i =>
            //   {
            //       reader.ReadGet(files[i], ref allcity);
            //   });


        }



    }
}
