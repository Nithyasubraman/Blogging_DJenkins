namespace BloggingSite.Models
{
    public class ImageEntity
    {
            public int Id { get; set; }
            public byte[] ImageData { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        
    }
}
