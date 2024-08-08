using Booksy.Models;
using System.Collections.Generic;

namespace Booksy.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public Comment NewComment { get; set; }
        public Comment EditComment { get; set; }
    }
}
