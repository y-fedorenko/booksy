﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.Models
{
    public class Serie
    {
        public int SeriesId { get; set; }
        public string SeriesName     { get; set; }
        public string? SeriesDescription { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
