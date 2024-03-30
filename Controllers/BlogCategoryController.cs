using BloggingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        public readonly AppDbContext _dbContext;

        public BlogCategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet("categories/{categoryId}")]


      //  [HttpGet("filter")]
      //  public async Task<IActionResult> FilterBlogPosts(
      // [FromQuery] string category = null,
      // [FromQuery] string publishedDate = null,
      //[FromQuery] string author = null)
      //  {
      //      var blogPosts = _dbContext.BlogPosts
      //          .Include(bp => bp.Category)
      //          //.Include(bp => bp.Comments)
      //          //.ThenInclude(c=>c.Author)
      //          .AsQueryable();

      //      if (!string.IsNullOrEmpty(category))
      //      {
      //          blogPosts = blogPosts.Where(bp => bp.Category == category);
      //      }
      //      else if (!string.IsNullOrEmpty(publishedDate))
      //      {
      //          blogPosts = blogPosts.Where(bp => bp.PostedDate == publishedDate);
      //      }
      //      else if (!string.IsNullOrEmpty(author))
      //      {
      //          blogPosts = blogPosts.Where(bp => bp.Author.Contains(author));
      //      }

      //      var filteredBlogPosts = await blogPosts.ToListAsync();

      //      return Ok(filteredBlogPosts);
      //  }

    }
}
