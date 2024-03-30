using System.ComponentModel.DataAnnotations;

namespace BloggingSite.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public byte[] Image { get; set; }

        public DateTime PublishedDate { get; set; }

        public  User Author { get; set; }  //F.K

        public Category Category { get; set; }  //F.K

        public ICollection<Comments> Comments { get; set; } = new List<Comments>();

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
