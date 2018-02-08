using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task
{
    class StreamReaderEnumerator : IEnumerator<string>
    {
        private StreamReader _sr;
        string fileOUT = "";
        public StreamReaderEnumerator(string file)
        {

            fileOUT = file;
            _sr = new StreamReader(file, Encoding.Default);
        }

        private string _current;
        // Implement the IEnumerator(T).Current publicly, but implement 
        // IEnumerator.Current, which is also required, privately.
        public string Current
        {
            get
            {
                if (_sr == null || _current == null)
                {
                    throw new InvalidOperationException();
                }
                return _current;
            }
        }

        private object Current1
        {

            get { return this.Current; }
        }

        object IEnumerator.Current
        {
            get { return Current1; }
        }

        // Implement MoveNext and Reset, which are required by IEnumerator.
        public bool MoveNext()
        {
           // Console.WriteLine("Считываем строку файла "+fileOUT );
            _current = _sr.ReadLine();
            if (_current == null)
                return false;
            return true;
        }

        public void Reset()
        {
            _sr.DiscardBufferedData();
            _sr.BaseStream.Seek(0, SeekOrigin.Begin);
            _current = null;
        }

        // Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources.
                }
                _current = null;
                if (_sr != null)
                {
                    _sr.Close();
                    _sr.Dispose();
                }
            }

            this.disposedValue = true;
        }

        ~StreamReaderEnumerator()
        {
            Dispose(false);
        }
    }
}
