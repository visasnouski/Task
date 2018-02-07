using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class ParserStart
    {
        public IParser _parse;

        public ParserStart(IParser ParserDI)
        {
            _parse = ParserDI;
        }

        public Dictionary<string, int> GetCityDictionary(IEnumerable<string> listEnum)
        {
            try
            {
              return  _parse.GetCityDictionary(listEnum);
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
                return null;
            }
        }
    }
}
