using ReactApp.Models;
using System.Collections.Generic;

namespace ReactApp.Data
{
    public interface IShareRepository : IEntityBaseRepository<Share>
    {
        List<Story> StoriesSharedToUser(string userId);
    }
}
