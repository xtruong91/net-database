using ReactApp.Models;

namespace ReactApp.Data
{
    public interface IStoryRepository : IEntityBaseRepository<Story>
    {
        bool IsOwner(string storyId, string userId);
        bool IsInvited(string storyId, string userId);
    }
}
