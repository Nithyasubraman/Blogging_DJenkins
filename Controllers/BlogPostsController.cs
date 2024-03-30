using BloggingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace BloggingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        //private readonly ImagesController _imagesController;
        //public BlogPostsController(AppDbContext dbContext, ImagesController imagesController)

        public BlogPostsController(AppDbContext dbContext,IWebHostEnvironment environment,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _environment = environment;
            _configuration = configuration;
            //_imagesController = imagesController;
        }

        // Other action methods...
        [HttpPost]
        public async Task<ActionResult<BlogPostCreateDto>> CreateUser([FromForm] BlogPostCreateDto blog)
        {

            // Generate a unique file name
            var uniqueFileName = $"{Guid.NewGuid()}_{blog.FeaturedImage.FileName}";

            // Save the image to a designated folder (e.g., wwwroot/images)
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await blog.FeaturedImage.CopyToAsync(stream);
            }

            // Store the file path in the database
            blog.UFileName = uniqueFileName;


            BlogPostCreateDto blogPost = new BlogPostCreateDto()
            {
                Title = blog.Title,
                Content = blog.Content,
                Author = blog.Author,
                PostedDate = blog.PostedDate,
                Tag = blog.Tag,
                Category = blog.Category,
               

                FeaturedImage = blog.FeaturedImage,
                UFileName = blog.UFileName,

            };

            _dbContext.BlogPosts.Add(blogPost);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]

        public IActionResult GetAllBlogs()
        {
            var blogs = _dbContext.BlogPosts.ToList();

            var blogList = new List<object>();

            foreach (var blog in blogs)
            {
                var blogData = new
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    Author = blog.Author,
                    PostedDate = blog.PostedDate,
                    Tag = blog.Tag,
                    Category = blog.Category,
                    Likes = blog.Likes,
                    UFileName = blog.UFileName,
                    //FeaturedImage = blog.FeaturedImage,
                    imageUrl = String.Format("{0}://{1}{2}/wwwroot/images/{3}", Request.Scheme, Request.Host, Request.PathBase, blog.UFileName),
                    Comments= _dbContext.comments.Where(x => x.PostCreateDto.Id==blog.Id).Include(x=>x.UserSignup).ToList()
                };

                blogList.Add(blogData);
            }

            return Ok(blogList);
        }


        [HttpPost("like/{id}")]
        public IActionResult LikePost(int id)
        {
            var post = _dbContext.BlogPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }


            post.Likes+=1;  // Increment the likes count
            _dbContext.BlogPosts.Update(post);
            _dbContext.SaveChanges();

            return NoContent();
        }


        [HttpPost("unlike/{id}")]
        public IActionResult UnlikePost(int id)
        {
            var post = _dbContext.BlogPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            if (post.Likes > 0)
            {
                post.Likes-=1;  // Decrement the likes count if it's greater than 0
            }
            _dbContext.BlogPosts.Update(post);
            _dbContext.SaveChanges();

            return NoContent();
        }



        [HttpGet("{id}/Image")]
        public IActionResult GetImage(int id)
        {
            var cart = _dbContext.BlogPosts.Find(id);
            if (cart == null)
            {
                return NotFound(); // User not found
            }

            // Construct the full path to the image file
            var imagePath = Path.Combine(_environment.WebRootPath, "images", cart.UFileName);

            // Check if the image file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Image file not found
            }

            // Serve the image file
            return PhysicalFile(imagePath, "image/jpeg");
        }


    }
}




