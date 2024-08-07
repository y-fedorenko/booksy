﻿// <auto-generated />
using System;
using Booksy.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booksy.DAL.Migrations
{
    [DbContext(typeof(BooksyDbContext))]
    [Migration("20240807153546_IdFix")]
    partial class IdFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booksy.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Biography")
                        .HasMaxLength(65535)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Booksy.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CoverUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(65535)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DownloadUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("SeriesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Booksy.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(65535)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CommentId");

                    b.HasIndex("BookId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Booksy.Models.Serie", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeriesId"));

                    b.Property<string>("SeriesDescription")
                        .HasMaxLength(65535)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SeriesId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Booksy.Models.Book", b =>
                {
                    b.HasOne("Booksy.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Booksy.Models.Serie", "Serie")
                        .WithMany("Books")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("Booksy.Models.Comment", b =>
                {
                    b.HasOne("Booksy.Models.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Booksy.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Booksy.Models.Book", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Booksy.Models.Serie", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
