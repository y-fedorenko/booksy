using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Booksy.Models
{
    public class BooksAndAuthorsViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
