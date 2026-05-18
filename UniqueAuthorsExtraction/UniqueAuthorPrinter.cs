using System;
using System.Collections.Generic;

namespace BooksAuthorsPrinter
{
    public class UniqueAuthorPrinter : ActiveObject
    {
        private readonly BlockingBuffer<string> _in;
        private readonly HashSet<string> _printed = new HashSet<string>();

        public UniqueAuthorPrinter(BlockingBuffer<string> inBuff)
        {
            _in = inBuff;
        }

        protected override void Run()
        {
            while (!IsStopped)
            {
                string author = _in.Pop();
                if (_printed.Add(author))
                    Console.WriteLine(author);
            }
        }
    }
}