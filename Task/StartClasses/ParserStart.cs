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

        public Dictionary<string, int> GetData(IEnumerable<string> listEnum)
        {

            Dictionary<string, int> dc = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var x in listEnum)
            {
                string key = GetName(x);
                int value = GetPopulation(x);
                if (dc.ContainsKey(key))
                {
                    dc[key] += value;

                }
                else
                {
                    dc.Add(key, value);
                }
            }
            return dc;
        }
        private static int GetPopulation(string line)
        {
            try
            {
                return Convert.ToInt32(line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return 0;
            }
        }
        private static string GetName(string line)
        {
            try
            {
                return line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return "";
            }
        }
    }
}
