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

        public async Task CreateUser(User user)
        {
            await usersCollection.InsertOneAsync(user);
        }

        public async Task DeleteUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            await usersCollection.DeleteOneAsync(filter);
        }

        public async Task <IEnumerable<User>> GetUser()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateUser(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            await usersCollection.ReplaceOneAsync(filter, user);
        }
    }
}
