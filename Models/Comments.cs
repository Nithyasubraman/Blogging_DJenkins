using System.ComponentModel.DataAnnotations;

namespace BloggingSite.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public string? CommentContent { get; set; }

        public BlogPostCreateDto PostCreateDto { get; set; }

        public UserSignup UserSignup { get; set; }


    }
}
