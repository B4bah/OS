using System.Collections.Generic;
using System.Threading;

namespace BooksAuthorsPrinter
{
    public class BlockingBuffer<T>
    {
        private List<T> _buffer = new List<T>();
        private Semaphore _emptyLock;
        private Semaphore _fullLock;

        public BlockingBuffer(int maxSize)
        {
            _emptyLock = new Semaphore(0, maxSize);
            _fullLock = new Semaphore(maxSize, maxSize);
        }

        public void Add(T value)
        {
            _fullLock.WaitOne();
            lock (_buffer) { _buffer.Add(value); }
            _emptyLock.Release();
        }

        public T Pop()
        {
            T value;
            _emptyLock.WaitOne();
            lock (_buffer)
            {
                value = _buffer[0];
                _buffer.RemoveAt(0);
            }
            _fullLock.Release();
            return value;
        }
    }
}