using System.Collections.Generic;
using Booksy.Models;

namespace Booksy.ViewModels {
    public class BookCreateViewModel {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Serie> Series { get; set; }
    }
}
