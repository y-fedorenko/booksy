using System.ComponentModel.DataAnnotations;


namespace Booksy.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Category cannot be longer than 50 characters.")]
        public string Category { get; set; }

        public int? AuthorId { get; set; }
        public int? SeriesId { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string? CoverUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string? DownloadUrl { get; set; }

        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Serie>? Series { get; set; }
    }
}
