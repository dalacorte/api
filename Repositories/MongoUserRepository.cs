using Api.Entities;
using MongoDB.Bson;
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
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public MongoUserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public void CreateUser(User user)
        {
            usersCollection.InsertOne(user);
        }

        public void DeleteUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            usersCollection.DeleteOne(filter);
        }

        public IEnumerable<User> GetUser()
        {
            return usersCollection.Find(new BsonDocument()).ToList();
        }

        public User GetUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return usersCollection.Find(filter).SingleOrDefault();
        }

        public void UpdateUser(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            usersCollection.ReplaceOne(filter, user);
        }
    }
}
