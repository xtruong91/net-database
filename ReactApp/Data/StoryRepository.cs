using ReactApp.Models;

namespace ReactApp.Data
{
    public class StoryRepository : EntityBaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(BlogContext context) : base(context) { }

        public bool IsInvited(string storyId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsOwner(string storyId, string userId)
        {
            var story = this.GetSingle(s => s.Id == storyId);
            return story.OwnerId == userId;
        }
    }
}
