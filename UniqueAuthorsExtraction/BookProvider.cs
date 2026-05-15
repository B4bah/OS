namespace BooksAuthorsPrinter
{
    public class BookProvider : ActiveObject
    {
        private readonly BlockingBuffer<Book> _out;

        public BlockingBuffer<Book> Out => _out;

        private static readonly Book[] _books =
{
    new Book("The C Programming Language",          "Brian Kernighan"),
    new Book("The Unix Programming Environment",    "Brian Kernighan"),
    new Book("Clean Code",                          "Robert C. Martin"),
    new Book("The Pragmatic Programmer",            "David Thomas"),
    new Book("Code Complete",                       "Steve McConnell"),
    new Book("Design Patterns",                     "Erich Gamma"),
    new Book("Refactoring",                         "Martin Fowler"),
    new Book("The Mythical Man-Month",              "Fred Brooks"),
    new Book("Introduction to Algorithms",          "Thomas Cormen"),
    new Book("Structure and Interpretation",        "Harold Abelson"),
    new Book("Domain-Driven Design",                "Eric Evans"),
    new Book("Working Effectively with Legacy Code","Michael Feathers"),
    new Book("Continuous Delivery",                 "Jez Humble"),
    new Book("Release It!",                         "Michael Nygard"),
    new Book("Algorithms",                          "Robert Sedgewick"),
    new Book("Programming Pearls",                  "Jon Bentley"),
    new Book("The Art of Computer Programming",     "Donald Knuth"),
    new Book("Compilers: Principles",               "Alfred Aho"),
    new Book("Operating System Concepts",           "Abraham Silberschatz"),
    new Book("Computer Networks",                   "Andrew Tanenbaum"),
    new Book("Modern Operating Systems",            "Andrew Tanenbaum"),
    new Book("Distributed Systems",                 "Andrew Tanenbaum"),
    new Book("Database System Concepts",            "Abraham Silberschatz"),
    new Book("Artificial Intelligence",             "Stuart Russell"),
    new Book("Pattern Recognition",                 "Christopher Bishop"),
    new Book("Deep Learning",                       "Ian Goodfellow"),
    new Book("Fluent Python",                       "Luciano Ramalho"),
    new Book("Learning Python",                     "Mark Lutz"),
    new Book("Python Cookbook",                     "David Beazley"),
    new Book("Effective Java",                      "Joshua Bloch"),
    new Book("Java Concurrency in Practice",        "Brian Goetz"),
    new Book("Head First Design Patterns",          "Eric Freeman"),
    new Book("Test-Driven Development",             "Kent Beck"),
    new Book("Extreme Programming Explained",       "Kent Beck"),
    new Book("The Clean Coder",                     "Robert C. Martin"),
    new Book("Clean Architecture",                  "Robert C. Martin"),
};

        public BookProvider(int bufferSize)
        {
            _out = new BlockingBuffer<Book>(bufferSize);
        }

        protected override void Run()
        {
            int i = 0;
            while (!IsStopped)
            {
                _out.Add(_books[i % _books.Length]);
                i++;
            }
        }
    }
}