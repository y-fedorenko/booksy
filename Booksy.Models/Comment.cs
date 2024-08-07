using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int BookId { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public DateTime CommentTime { get; set; }


        public Book Book { get; set; }
    }
}
