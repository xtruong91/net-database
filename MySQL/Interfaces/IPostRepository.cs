using MySQL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySQL.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> Get(int id);
        Task Insert(Post post);
        Task Update(Post post);
        Task Delete(int id);
        Task DeleteAll();
    }
}
