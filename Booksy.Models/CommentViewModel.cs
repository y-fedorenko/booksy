using Booksy.Models;
using System.ComponentModel.DataAnnotations;

public class CommentViewModel
{
    public int CommentId { get; set; }
    public int BookId { get; set; }

    [Required(ErrorMessage = "Comment text is required")]
    [MinLength(1, ErrorMessage = "Comment text must be at least 1 character long")]
    [MaxLength(65535, ErrorMessage = "Comment text cannot be longer than 65535 characters")]
    public string CommentText { get; set; }

    [Required(ErrorMessage = "User name is required")]
    [MinLength(1, ErrorMessage = "User name must be at least 1 character long")]
    [MaxLength(255, ErrorMessage = "User name cannot be longer than 255 characters")]
    public string UserName { get; set; }
        
}
