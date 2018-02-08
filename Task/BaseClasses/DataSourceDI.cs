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
      
        public IEnumerable<string> GetData(object obj)
        {
            try
            {
                string files = (string)obj;
                IEnumerable<string> data = from line in new StreamReaderEnumerable(files)
                                           where line.Contains(',')
                                           select line;

                return data;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<string> GetData()
        {
            throw new NotImplementedException();
        }


    }
}
