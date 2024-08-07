﻿using Booksy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.DAL
{
    public class BooksyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Serie> Series { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public BooksyDbContext(DbContextOptions<BooksyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PK
            modelBuilder.Entity<Book>().HasKey(book => book.BookId);
            modelBuilder.Entity<Author>().HasKey(author => author.AuthorId);
            modelBuilder.Entity<Serie>().HasKey(serie => serie.SeriesId);
            modelBuilder.Entity<Comment>().HasKey(serie => serie.CommentId);

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

            modelBuilder.Entity<Serie>()
                .Property(s => s.SeriesName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Serie>()
                .Property(s => s.SeriesDescription)
                .HasMaxLength(65535);

            modelBuilder.Entity<Comment>()
                .Property(c => c.CommentText)
                .IsRequired()
                .HasMaxLength(65535);

            modelBuilder.Entity<Comment>()
                .Property(c => c.UserName)
                .IsRequired()
                .HasMaxLength(255);

            // Relations
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                .HasOne(book => book.Serie)
                .WithMany(a => a.Books)
                .HasForeignKey(book => book.SeriesId)
                .OnDelete(DeleteBehavior.SetNull);
            //Comment deleted => nothing happens to the book
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.NoAction);
            //Book deleted => all the comments are gone
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Book)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
