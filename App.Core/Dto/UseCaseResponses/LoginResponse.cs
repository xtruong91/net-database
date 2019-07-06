using App.Core.Interfaces;
using System.Collections.Generic;

namespace App.Core.Dto.UseCaseResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }
        public IEnumerable<Error> Errors { get; }

        public LoginResponse(IEnumerable<Error> errors, bool success=false, string message=null)
            : base(success, message)
        {

        }

        public LoginResponse(Token token, bool success=false, string message=null)
            : base(success, message)
        {

        }
    }
}
