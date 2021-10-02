using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto
{
    public class UserDTO
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public string ProfilePicture { get; init; }
        public bool EmailVerified { get; init; }
    }
}
