using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   public class ReaderStart
    {
        private IFromDI _Read;
        public ReaderStart(IFromDI ReaderDI)
        {
            _Read = ReaderDI;
        }
        public void ReadGet(string filepath, ref List<City> allcity)
        {
            try
            {
                _Read.GetAllCityFrom(filepath, ref allcity);
            }
            catch (Exception p)
            {
                Console.WriteLine(p.Message);
            }
        }
    }
}
