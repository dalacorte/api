using Api.Entities;
using System;
using System.Collections.Generic;

namespace Api.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUser(Guid id);
    }
}