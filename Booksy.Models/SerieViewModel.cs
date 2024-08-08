using Booksy.Models;
using System.Collections.Generic;

namespace Booksy.Models
{
    public class SerieViewModel
    {
        public int SerieId { get; set; }
        public string SeriesName { get; set; }
        public string? SeriesDescription { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
