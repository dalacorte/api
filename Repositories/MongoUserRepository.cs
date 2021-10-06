using Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class MongoUserRepository : IUserRepository
    {
        private const string databaseName = "api";
        private const string collectionName = "users";

        private readonly IMongoCollection<User> usersCollection;

        public MongoUserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
