using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BloggingSite.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
           public DbSet<AdminAction> adminactions {  get; set; }

           public DbSet<Category> categories { get; set; }

           public DbSet<Comments> comments { get; set; }

           public DbSet<Post> posts { get; set; }


           public DbSet<Tag> tags { get; set; }

           public DbSet<User> users { get; set; }

           public DbSet<AdminSignup> adminsignup { get; set; }

           public DbSet<UserSignup> userSignup { get; set; }

           public DbSet<Login> login { get; set; }

           //public DbSet<ImageModel> images { get; set; }

           public DbSet<ImageEntity> Images { get; set; }

          public DbSet<BlogPostCreateDto> BlogPosts { get; set; }

    }
}
