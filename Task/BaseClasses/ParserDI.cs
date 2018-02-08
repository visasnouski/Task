using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class ParserDI : IParser
    {

        public Dictionary<string, int> GetCityDictionary(IEnumerable<string> listEnum)
        {
            Dictionary<string, int> dc = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var x in listEnum)
            {
                Split(x, out string key, out int popul);
                if (key != null & key != "")
                    if (dc.ContainsKey(key))
                    {
                        dc[key] += popul;
                    }
                    else
                    {
                        dc.Add(key, popul);
                    }
            }
            return dc;
        }
        private static void Split(string line, out string name, out int population)
        {
            name = null;
            population = 0;
            try
            {
                string[] sp = Regex.Split(line, @"(?=.)(,)(?=\d)");
                name = sp[0];
                population = Convert.ToInt32(sp[2]);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                name = null;
                population = 0;
            }
        }
    }
}
