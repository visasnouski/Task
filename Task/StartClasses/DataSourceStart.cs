using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class DataSourceStart
    {
        private IDataSource _DataSource;
        public  DataSourceStart(IDataSource DataSourceDI)
        {
            _DataSource = DataSourceDI;
        }
        public IEnumerable<string> GetData(object obj)
        {
            try
            {
              return  _DataSource.GetData(obj);
            }
            catch (Exception p)
            {
                Console.WriteLine(p.Message);
                return null;
            }
        }

        public IEnumerable<string> GetData()
        {
            throw new NotImplementedException();

        }
    }
}
