using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new();

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await Task.FromResult(users);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = users.Where(user => user.Id == id).SingleOrDefault();
            return await Task.FromResult(user);
        }

        public async Task CreateUserAsync(User user)
        {
            users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var index = users.FindIndex(u => u.Id == user.Id);
            users[index] = user;
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var index = users.FindIndex(u => u.Id == id);
            users.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
