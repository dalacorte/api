using Api.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class MongoProfessorRepository : IProfessorRepository
    {
        private const string databaseName = "api";
        private const string collectionName = "professors";

        private readonly IMongoCollection<Professor> professorCollection;
        private readonly FilterDefinitionBuilder<Professor> filterBuilder = Builders<Professor>.Filter;

        public MongoProfessorRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            professorCollection = database.GetCollection<Professor>(collectionName);
        }

        public async Task CreateProfessor(Professor professor)
        {
            await professorCollection.InsertOneAsync(professor);
        }

        public async Task DeleteProfessor(Guid id)
        {
            var filter = filterBuilder.Eq(professor => professor.Id, id);
            await professorCollection.DeleteOneAsync(filter);
        }

        public async Task <IEnumerable<Professor>> GetProfessor()
        {
            return await professorCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Professor> GetProfessor(Guid id)
        {
            var filter = filterBuilder.Eq(professor => professor.Id, id);
            return await professorCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateProfessor(Professor professor)
        {
            var filter = filterBuilder.Eq(existingProfessor => existingProfessor.Id, professor.Id);
            await professorCollection.ReplaceOneAsync(filter, professor);
        }
    }
}
