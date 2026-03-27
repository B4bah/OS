using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryView
{
    class BookSelectors
    {
        static public List<String> SelectAuthors(IBooksVisitor library)
        {
            List<String> result = new List<String>();
            library.VisitBooks(Book => result.Add(Book.Title));
            return result;
        }

        static public string Title(Book book)
        {
            return book.title;
        }

        static public string All(Book book)
        {
            return book.ToString();
        }
    }
}
