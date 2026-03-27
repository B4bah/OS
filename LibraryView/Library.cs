using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryView
{
    public class Library : ILibrary
    {
        List<Book> _library = new List<Book>();

        public Library(ILibDataProvider libDataProvider)
        {
            libDataProvider.VisitBooks(_library.Add);
        }

        public List<string> GetAuthors()
        {
            List<String> result = new List<String>();
            foreach (Book book in _library)
            {
                result.Add(book.author);
            }
            return result;
            //return _library.Select(book => book.author).ToList();
        }

        public List<string> GetBooksinfoByAuthor(string author)
        {
            List<String> result = new List<String>();
            foreach (Book book in _library)
            {
                if (book.author == author)
                result.Add(book.ToString());
            }
            return result;
        }

        public List<string> GetBooksInfoByTitle(string title)
        {
            List<String> result = new List<String>();
            foreach (Book book in _library)
            {
                if (book.title == title)
                    result.Add(book.ToString());
            }
            return result;
        }

        public List<string> GetTitles()
        {
            return _library.Select(book => book.title).ToList();
        }
    }
}
