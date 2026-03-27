using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryView
{
    public class LibDataProvider : ILibDataProvider
    {
        public void VisitBooks(BookVisitor bookVisitor)
        {
            List<Book> library = new List<Book>
            {
                new Book("Mark Baruish", "How to become a millionare", 2025),
                new Book("George Orwel", "1984", 1970),
                new Book("Stan Lee", "Spider-Man", 1960),
                new Book("Stan Lee", "Iron-Man", 1958)
            };

            foreach (Book book in library)
            {
                bookVisitor(book);
            }
        }
    }
}