using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactApp.Mocker
{
    public interface IMocksPacker
    {
        Task<Pack> GetPack(List<string> usernames);
    }
}
