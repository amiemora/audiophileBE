using AudiophileBE.Entities;

namespace AudiophileBE.Services
{
    public static class PostService
    {
        static List<Post> Posts { get; }
        static int PostId { get; }

        static PostService()
        {
            Posts = new List<Post>
            {

            };
        }

        public static List<Post> GetAll() => Posts;

      
        public static void Add(Post post)
        {
            
            Posts.Add(post);
        }
    }
}
