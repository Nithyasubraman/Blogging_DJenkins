namespace BloggingSite.Models
{
    public class CommentDTO
    {
        public string Comment { get; set; }

        
        public int Blogid {  get; set; }

        public int   UserId { get; set; }
    }
}
