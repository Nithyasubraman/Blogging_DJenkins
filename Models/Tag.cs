namespace BloggingSite.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string? TagName { get; set; }

        public ICollection<Post> Posts { get; set; }  = new List<Post>();


    }
}
