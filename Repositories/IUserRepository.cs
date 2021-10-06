using Api.Entities;
using System;
using System.Collections.Generic;

namespace Api.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUser(Guid id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}