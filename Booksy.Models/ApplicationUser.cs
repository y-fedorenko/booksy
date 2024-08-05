using Microsoft.AspNet.Identity.EntityFramework;

namespace Booksy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<CartItem> CartItems { get; set; }
    }
}

