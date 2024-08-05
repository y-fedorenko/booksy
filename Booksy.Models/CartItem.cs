using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Booksy.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }

        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
    }
}
