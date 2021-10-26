using Api.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class MongoTagRepository : ITagRepository
    {
        private const string databaseName = "api";
        private const string collectionName = "tags";

        private readonly IMongoCollection<Entities.Tag> tagsCollection;
        private readonly FilterDefinitionBuilder<Entities.Tag> filterBuilder = Builders<Entities.Tag>.Filter;

        public MongoTagRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            tagsCollection = database.GetCollection<Entities.Tag>(collectionName);
        }

        public async Task <IEnumerable<Entities.Tag>> GetTag()
        {
            return await tagsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateTag(Entities.Tag tag)
        {
            await tagsCollection.InsertOneAsync(tag);
        }
    }
}
