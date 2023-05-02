using BlazorBlogProjekt.Shared;

namespace BlazorBlogProjekt.Client.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetBlogPosts();

        Task<BlogPost> GetBlogPostByUrl(string url);
    }
}
