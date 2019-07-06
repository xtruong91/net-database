using App.Core.Dto.UseCaseResponses;
using App.Core.Interfaces;

namespace App.Core.Dto.UseCaseRequests
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginRequest(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
