using App.Core.Dto;
using System.Threading.Tasks;

namespace App.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string username);
    }
}
