using ReactApp.Models;

namespace ReactApp.Data
{
    public class StoryRepository : EntityBaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(BlogContext context) : base(context) { }

        public bool IsOwner(string storyId, string userId)
        {
            var story = this.GetSingle(storyId);
            return story.OwnerId == userId;
        }
    }
}
