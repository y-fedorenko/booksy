using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int? AuthorId { get; set; }
        public int? SeriesId { get; set; }

        public string? CoverUrl { get; set; }
        public string? DownloadUrl { get; set; }

        public Author Author { get; set; }
        public Serie Serie { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
