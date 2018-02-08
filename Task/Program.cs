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
            args=new string[] { @"f:\testtask\base\" }; 
           if (args.Length>0)
            {
                path = args[0];
                if (path.Length >= 1 && Directory.Exists(path))
                {
                    try
                    {
                        string[] files = Directory.GetFiles(path);
                        Start(files);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Файл не найден");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Папка не найдена");
                }
            }
            
        }

        public static void Start(string[] files)
        {
            DataSourceStart _source = new DataSourceStart(new DataSourceDI());
            ParserStart _parse = new ParserStart(new ParserDI());
            Dictionary<string, int> allcity = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            int N = Convert.ToInt32(ConfigurationSettings.AppSettings["N"]);

            Parallel.For(0, files.Length, new ParallelOptions { MaxDegreeOfParallelism = N },  //Обработка файлов производится параллельно, максимум N файлов одновременно
                i =>
                {
                    IEnumerable<string> stringsFound = _source.GetData(files[i]);
                    Dictionary<string, int> cityinonefile = _parse.GetCityDictionary(stringsFound);

                    if (cityinonefile != null)
                    {
                        lock (cityinonefile)
                        {
                            AddRange(allcity, cityinonefile);
                        }
                    }
                    
                });
            WriterStart write = new WriterStart(new WriterDI());
            write.WriteData(allcity, "output.txt");
        }
        
        public static void AddRange(this Dictionary<string, int> source, Dictionary<string, int> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
                else
                {
                    source[item.Key] += item.Value;
                }
            }
        }
    }
}
