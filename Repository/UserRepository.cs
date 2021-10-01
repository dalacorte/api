using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class UserRepository
    {
        private readonly List<User> users = new()
        {
            new User { Id = Guid.NewGuid(), Email = "email@email.com", Name = "victor", ProfilePicture = "github.com/dalacorte", EmailVerified = true }
        };

        public IEnumerable<User> GetUser()
        {
            return users;
        }

        public User GetUser(Guid id)
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        }
    }
}
