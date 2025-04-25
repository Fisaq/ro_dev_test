using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterResponse
    {
        public Guid UserId;
        public IList<string>? Roles { get; set; } = null;
    }
}
