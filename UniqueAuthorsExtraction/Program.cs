using System;

namespace BooksAuthorsPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int bufferSize = 10;

            BookProvider        provider  = new BookProvider(bufferSize);
            AuthorExtractor     extractor = new AuthorExtractor(provider.Out, bufferSize);
            UniqueAuthorPrinter printer   = new UniqueAuthorPrinter(extractor.Out);

            provider.Start();
            extractor.Start();
            printer.Start();

            Console.ReadLine();

            provider.Stop();
            extractor.Stop();
            printer.Stop();
        }
    }
}