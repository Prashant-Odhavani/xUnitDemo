using xUnitDemo.Api.Models;

namespace xUnitDemo.UnitTests.Fixtures
{
    public static class PostFixture
    {
        public static List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post { Id = 1, Title = "Test Post", Body = "Test post description", UserId = 1 },
                new Post { Id = 2, Title = "Post 2", Body = "Test description", UserId = 2 }
            };
        }
    }
}
