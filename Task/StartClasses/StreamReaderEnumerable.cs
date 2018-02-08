using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class StreamReaderEnumerable:IEnumerable<string>
    {
        private string _filePath;
        public StreamReaderEnumerable(string filePath)
        {
            _filePath = filePath;
        }

        // Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
        public IEnumerator<string> GetEnumerator()
        {
            try
            {
                return new StreamReaderEnumerator(_filePath);
            }
            catch(Exception p)
            {
                Console.WriteLine(p.Message);
                return null;
            }
        }

        // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
        private IEnumerator GetEnumerator1()
        {
            try
            {
                return this.GetEnumerator();
            }
            catch (Exception p)
            {
                Console.WriteLine(p.Message);
                return null;
            }
}
        IEnumerator IEnumerable.GetEnumerator()
        {
            try
            {
                return GetEnumerator1();
            }
            catch (Exception p)
            {
                Console.WriteLine(p.Message);
                return null;
            }
        }
    }
}
