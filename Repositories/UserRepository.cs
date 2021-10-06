using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User { Id = Guid.NewGuid(), Email = "email@email.com", Name = "victor", ProfilePicture = "github.com/dalacorte", EmailVerified = true, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<User> GetUser()
        {
            return users;
        }

        public User GetUser(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(u => u.Id == user.Id);
            users[index] = user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(u => u.Id == id);
            users.RemoveAt(index);
        }
    }
}
