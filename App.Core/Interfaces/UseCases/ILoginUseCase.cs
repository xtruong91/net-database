using App.Core.Dto.UseCaseRequests;
using App.Core.Dto.UseCaseResponses;

namespace App.Core.Interfaces.UseCases
{
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
    {

    }
}
