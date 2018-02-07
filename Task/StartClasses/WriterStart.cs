using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class WriterStart
    {
        private IWriterDI _Write;
        public WriterStart(IWriterDI writerDI)
        {
            _Write = writerDI;
        }
        public void WriteData(Dictionary<string, int> allcity, string filename)
        {
            try
            {
                _Write.Write(allcity, filename);
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }
    }
}
