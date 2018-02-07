using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IFromDI
    {
       void GetAllCityFrom(string filepath, ref List<City> allcity);
    }
}
