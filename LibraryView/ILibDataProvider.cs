using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryView
{
    public delegate void BookVisitor(Book book);

    public interface ILibDataProvider
    {
        void VisitBooks(BookVisitor bookVisitor);
    }
}
