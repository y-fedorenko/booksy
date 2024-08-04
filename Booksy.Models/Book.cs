using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int AuthorID { get; set; }
        public int SeriesID { get; set; }

        public string CoverUrl { get; set; }
        public string DownloadUrl { get; set; }
    }
}
