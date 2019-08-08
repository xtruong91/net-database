using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReactApp.Models;

namespace ReactApp.Data
{
    public class LikeRepository : EntityBaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(BlogContext context) : base(context) { }
    }
}
