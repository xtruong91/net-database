﻿using System.Threading.Tasks;
using App.Core.Dto;
using App.Core.Dto.UseCaseRequests;
using App.Core.Dto.UseCaseResponses;
using App.Core.Interfaces;
using App.Core.Interfaces.Gateways.Repositories;
using App.Core.Interfaces.Services;
using App.Core.Interfaces.UseCases;

namespace App.Core.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        
        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                // confirm we have a user with the given name;
                var user = await _userRepository.FindByName(message.UserName);
                if(user != null)
                {
                    // validate password
                    if(await _userRepository.CheckPassword(user, message.Password))
                    {
                        // generate token;
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName), true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password") }));
            return false;
        }
    }
}
