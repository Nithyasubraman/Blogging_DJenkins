using System.ComponentModel.DataAnnotations;

namespace BloggingSite.Models
{
    public class User
    {
        [Key] 
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? UserEmail { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public ICollection<Post> Posts { get; set; }   = new List<Post>();

        public ICollection<Comments> Comments { get; set; } = new List<Comments>();


    }
}
