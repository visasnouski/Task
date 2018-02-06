using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    static class SplitCity
    {
        public static int Count(string line)
        {
            return line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int GetPopulation(string line)
        {
            return Convert.ToInt32(line.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
        }
        public static string GetName (string line)
        {
          return  line.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
       
    }
}
