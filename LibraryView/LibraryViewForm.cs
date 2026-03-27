using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryView
{
    public partial class LibraryViewForm : Form
    {
        enum SelectMode
        {
            Authors,
            Titles
        }

        ILibrary _library;
        SelectMode _currentSelection;
        public LibraryViewForm(ILibrary library)
        {
            _library = library;
            
            InitializeComponent();
        }

        private void btnTitles_Click(object sender, EventArgs e)
        {
            listBoxNames.Items.Clear();
            listBoxNames.Items.AddRange(_library.GetTitles().ToArray());
        }

        private void listBoxNames_Click(object sender, EventArgs e)
        {
            String text = listBoxNames.Text;
            if (text == null || text.Length == 0)
                return;

            List<String> infoList = _currentSelection.Authors
                                    ? _library.GetBooksinfoByAuthor(text)
                                    : _library.GetBooksInfoByTitle(text);
        }
    }
}
