using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Booksy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.DAL
{
    public class BooksyDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public BooksyDbContext(DbContextOptions<BooksyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //override cant change protection level, it is protected by default
        {
        }
    }
}
