using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class CompareStart
    {
        private ICompare _Compare;
        public CompareStart(ICompare CompareDI)
        {
            _Compare = CompareDI;
        }
        public void Comare( ref List<City> allcity,City one)
        {
            try
            {
                _Compare.Compare( ref allcity, one);
            }
            catch (Exception p)
            {
                Console.WriteLine(p.Message);
            }
        }
    }
}
