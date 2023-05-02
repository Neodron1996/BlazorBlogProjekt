using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorBlogProjekt.Shared;
using BlazorBlogProjekt.Client.Shared;
using BlazorBlogProjekt.Server.DBModel;
using Microsoft.EntityFrameworkCore;

namespace BlogProjekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly DataBaseContext _context;
        public List<BlogPost> Posts;

        public BlogController(DataBaseContext context, List<BlogPost> posts)
        {
            _context = context;
            Posts = posts;
        }
        
        [HttpGet]
        public ActionResult<List<BlogPost>> GetBlogPosts()
        {
            return Ok(Posts);
        }
        [HttpGet("{url}")]
        public ActionResult<BlogPost> GetOneBlogPost(string url)
        {
            var post = Posts.FirstOrDefault(p => p.PostUrl.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("Post not exist");
            }

            return Ok(post);
        }
    }
}
