using Api.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class MongoOrgRepository : IOrgRepository
    {
        private const string databaseName = "api";
        private const string collectionName = "orgs";

        private readonly IMongoCollection<Org> orgsCollection;
        private readonly FilterDefinitionBuilder<Org> filterBuilder = Builders<Org>.Filter;

        public MongoOrgRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            orgsCollection = database.GetCollection<Org>(collectionName);
        }

        public async Task CreateOrg(Org org)
        {
            await orgsCollection.InsertOneAsync(org);
        }

        public async Task DeleteOrg(Guid id)
        {
            var filter = filterBuilder.Eq(org => org.Id, id);
            await orgsCollection.DeleteOneAsync(filter);
        }

        public async Task <IEnumerable<Org>> GetOrg()
        {
            return await orgsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Org> GetOrg(Guid id)
        {
            var filter = filterBuilder.Eq(org => org.Id, id);
            return await orgsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateOrg(Org org)
        {
            var filter = filterBuilder.Eq(existingOrg => existingOrg.Id, org.Id);
            await orgsCollection.ReplaceOneAsync(filter, org);
        }
    }
}
