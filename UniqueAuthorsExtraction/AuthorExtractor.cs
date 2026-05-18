namespace BooksAuthorsPrinter
{
    public class AuthorExtractor : ActiveObject
    {
        private readonly BlockingBuffer<Book> _in;
        private readonly BlockingBuffer<string> _out;

        public BlockingBuffer<string> Out => _out;

        public AuthorExtractor(BlockingBuffer<Book> inBuff, int bufferSize)
        {
            _in = inBuff;
            _out = new BlockingBuffer<string>(bufferSize);
        }

        protected override void Run()
        {
            while (!IsStopped)
            {
                Book book = _in.Pop();
                _out.Add(book.Author);
            }
        }
    }
}