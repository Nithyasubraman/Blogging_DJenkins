using BloggingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public readonly AppDbContext _dbContext;

        public SearchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBlogs([FromQuery] string query, [FromQuery] string category = null, [FromQuery] string tag = null)
        {
            var blogPosts = _dbContext.BlogPosts.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                blogPosts = blogPosts.Where(bp => bp.Title.Contains(query) || bp.Content.Contains(query));
            }

            //if (!string.IsNullOrEmpty(category))
            //{
            //    blogPosts = blogPosts.Where(bp => bp.Category == category);
            //}

            if (!string.IsNullOrEmpty(tag))
            {
                blogPosts = blogPosts.Where(bp => bp.Tag == tag);
            }

            var results = await blogPosts
                //.Include(bp => bp.Comments)
                .ToListAsync();

            return Ok(results);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO comment)
        {
            if (comment == null || string.IsNullOrWhiteSpace(comment.Comment))
            {
                return BadRequest("The Comment field is required.");
            }

            var blogpost = _dbContext.BlogPosts.FirstOrDefault(s => s.Id == comment.Blogid);
            var user = _dbContext.userSignup.FirstOrDefault(u => u.Id == comment.UserId);

            if (blogpost == null || user == null)
            {
                return NotFound("Blog post or user not found.");
            }

            var blogs = new Comments()
            {
                CommentContent = comment.Comment,
                PostCreateDto = blogpost,
                UserSignup = user
            };

            _dbContext.comments.Add(blogs);
            await _dbContext.SaveChangesAsync();

            return Ok(blogs);
        }


        [HttpGet("GetComments/{blogPostId}")]
        public async Task<IActionResult> GetCommentsForBlogPost(int blogPostId)
        {
            // Check if the blog post exists
            var blogPostExists = await _dbContext.BlogPosts.AnyAsync(bp => bp.Id == blogPostId);
            if (!blogPostExists)
            {
                return NotFound("Blog post not found.");
            }

            // Retrieve the comments for the specified blog post
            var comments = await _dbContext.comments
                                           .Where(c => c.PostCreateDto.Id == blogPostId)
                                           .Select(c => new CommentDTO
                                           {
                                               Comment = c.CommentContent,
                                               Blogid = c.PostCreateDto.Id,
                                               UserId = c.UserSignup.Id
                                           })
                                           .ToListAsync();

            if (comments == null || comments.Count == 0)
            {
                return NotFound("No comments found for this blog post.");
            }

            return Ok(comments);
        }





        //[HttpPost]
        //public async Task<ActionResult<BlogPostCreateDto>> CreateComment([FromForm] CommentDTO comment)
        //{
        //    var blogpost = _dbContext.BlogPosts.FirstOrDefault(s => s.Id == comment.Blogid);

        //    var user = _dbContext.userSignup.FirstOrDefault(u => u.Id == comment.UserId);

        //    var blogs = new Comments()
        //    {
        //        CommentContent = comment.Comment,
        //        PostCreateDto = blogpost,
        //        UserSignup = user
        //    };

        //    _dbContext.comments.Add(blogs);

        //    return Ok(blogs);
        //}
    }
}
