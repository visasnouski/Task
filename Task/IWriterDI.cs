using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IWriterDI
    {
        void Write(List<City> allcity, string filename);
    }
}
