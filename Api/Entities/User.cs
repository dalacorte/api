using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string ProfilePicture { get; init; }
        public bool EmailVerified { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
