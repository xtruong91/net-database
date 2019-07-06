using App.Core.Domain.Entities;
using App.Core.Dto.UseCaseRequests;
using App.Core.Dto.UseCaseResponses;
using App.Core.Interfaces;
using App.Core.Interfaces.Gateways.Repositories;
using App.Core.Interfaces.UseCases;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.FirstName, message.LastName, message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
