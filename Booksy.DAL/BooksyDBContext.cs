using Booksy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booksy.DAL
{
    public class BooksyDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public BooksyDbContext(DbContextOptions<BooksyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  

            // PK
            modelBuilder.Entity<Book>().HasKey(book => book.BookID);
            modelBuilder.Entity<Author>().HasKey(author => author.AuthorId);
            modelBuilder.Entity<Serie>().HasKey(serie => serie.SeriesId);
            modelBuilder.Entity<CartItem>().HasKey(cartItem => cartItem.CartItemId);

            // Properties
            modelBuilder.Entity<Book>()
                .Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Book>()
                .Property(book => book.Description)
                .IsRequired()
                .HasMaxLength(65535);

            modelBuilder.Entity<Book>()
                .Property(book => book.Price)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(book => book.Category)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Book>()
                .Property(book => book.CoverUrl)
                .HasMaxLength(2083);

            modelBuilder.Entity<Book>()
                .Property(book => book.DownloadUrl)
                .HasMaxLength(2083);

            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Author>()
                .Property(a => a.LastName)
                .HasMaxLength(255);

            modelBuilder.Entity<Author>()
                .Property(a => a.Biography)
                .HasMaxLength(65535);

            modelBuilder.Entity<Author>()
                .Property(a => a.ImageUrl)
                .HasMaxLength(2083);

            modelBuilder.Entity<Serie>()
                .Property(s => s.SeriesName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Serie>()
                .Property(s => s.SeriesDescription)
                .HasMaxLength(65535);

            // Relations
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(book => book.AuthorID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                .HasOne(book => book.Serie)
                .WithMany(a => a.Books)
                .HasForeignKey(book => book.SeriesID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CartItem>()
                .HasOne(cart => cart.Book)
                .WithMany()
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserId);
        }
    }
}
