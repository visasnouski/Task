using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    interface IDataSource
    {
        IEnumerable<string> GetData(object obj);

        IEnumerable<string> GetData();
    }
}
