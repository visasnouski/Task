using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   public interface ICompare
    {
        void Compare(ref List<City> allcity, City city);
    }
}
