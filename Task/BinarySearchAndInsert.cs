using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class BinarySearchAndInsert : IComparer<City>
    {
        public int Compare(City x, City y)
        {
            
            if (x.Key == null)
            {
                if (y.Key == null)
                {
                    // If x.Key is null and y.Key is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x.Key is null and y.Key is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x.Key is not null...
                //
                if (y.Key == null)
                // ...and y.Key is null, x.Key is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y.Key is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Key.CompareTo(y.Key);
                   // int retval = String.Compare(x.Key, y.Key, true);
                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.Key.CompareTo(y.Key);
                    }
                }
            }
        }
    }
}
