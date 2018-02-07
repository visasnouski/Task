using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Test
{
    class FromFIleDIMock : IFromDI
    {
        public void GetAllCityFrom(string filepath, ref List<City> allcity)
        {
            throw new NotImplementedException();
        }
    }
}
