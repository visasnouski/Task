using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class CityEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string b1, string b2)
        {
            if (b2 == null && b1 == null)
            {
                return true;
            }
            else if (b1 == null | b2 == null)
                return false;
            else if (b1 == b2)
                return true;
            else
                return false;
        }

      

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }

    }
}
