using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto
{
    public record ProfessorDTO
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public IEnumerable<Post> Post { get; init; }
        public string ProfilePicture { get; init; }
        public bool EmailVerified { get; init; }
        public bool CanCreate { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
