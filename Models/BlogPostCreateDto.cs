using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingSite.Models
{
    public class BlogPostCreateDto
    {
        [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public string PostedDate { get; set; }
            public string Tag { get; set; }
           
            //public int CategoryId { get; set; }
            public string Category { get; set; }

            public int Likes { get; set; }


            [NotMapped]
            public IFormFile? FeaturedImage { get; set; }

            public string? UFileName { get; set; }

            

           // public ICollection<Comments> Comments { get; set; } = new List<Comments>();

            //public List<Comments> Comments { get; set; }

    }
}
