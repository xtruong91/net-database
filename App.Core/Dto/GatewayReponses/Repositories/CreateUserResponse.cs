using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Dto.GatewayReponses.Repositories
{
    public class CreateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null)
            : base(success, errors)
        {
            Id = id;
        }
    }
}
