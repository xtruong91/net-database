using App.Core.Interfaces;
using System.Collections.Generic;

namespace App.Core.Dto.UseCaseResponses
{
    public class RegisterUserResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterUserResponse(IEnumerable<string> errors, bool success = false, string message = null)
            : base(success, message)
        {

        }

        public RegisterUserResponse(string id, bool success=false, string message=null)
            : base(success, message)
        {
            Id = id;
        }
    }
}
