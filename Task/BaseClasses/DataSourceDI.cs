using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task
{
    class DataSourceDI : IDataSource
    {
        static IEnumerable<string> alllines;
        public IEnumerable<string> GetData()
        {
            string path = Program.path;
            if (path.Length >= 1 && Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                return NeeData(files);
            }
            else
            {
                Console.WriteLine("Папка не найдена");
                return null;
            }

        }
        static IEnumerable<string> lines;
        private IEnumerable<string> NeeData(string[] files)
        {


            List<string> alldata = new List<string>();

            string seperator = "";
            string itog = "";
            int N = Convert.ToInt32(ConfigurationSettings.AppSettings["N"]);
            Parallel.For(0, files.Length, new ParallelOptions { MaxDegreeOfParallelism = N },  //Обработка файлов производится параллельно, максимум N файлов одновременно
                i =>
               {
                   using (StreamReader reader = new StreamReader (files[i],Encoding.Default))
                   {
                       
                           string line = "";
                       lock (line)
                       {
                           while ((line = reader.ReadLine()) != null)
                           {

                               alldata.Add(line);

                           }
                       }
                   }
               });

            return alldata;

        }

    }
}
