using System.ComponentModel.DataAnnotations;

namespace BloggingSite.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        //public ICollection<Post> Posts { get; set; } = new List<Post>();

        //public ICollection<BlogPostCreateDto> BlogPosts { get; set; } = new List<BlogPostCreateDto>();

    }
}
