using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Dto
{
    public class Error
    {
        public string Code { get; }
        public string Description { get; }
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
