using BloggingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public AdminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Delete a blog post by ID
        [HttpDelete("blogposts/{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var post = _dbContext.BlogPosts.Find(id);
            if (post == null)
            {
                return NotFound(); // Post not found
            }

            _dbContext.BlogPosts.Remove(post);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Successfully deleted
        }

        // Delete a comment by ID
        [HttpDelete("comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _dbContext.comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound(); // Comment not found
            }

            _dbContext.comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Successfully deleted
        }

        // Delete a user by ID
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _dbContext.userSignup.FindAsync(id);
            if (user == null)
            {
                return NotFound(); // User not found
            }

            _dbContext.userSignup.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Successfully deleted
        }
    }
}
