using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryView
{
    public interface ILibrary
    {
        List<string> GetAuthors();

        List<string> GetTitles();

        List<string> GetBooksinfoByAuthor(string author);

        List<string> GetBooksInfoByTitle(string title);
    }
}
