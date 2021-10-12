using Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetUser();
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}