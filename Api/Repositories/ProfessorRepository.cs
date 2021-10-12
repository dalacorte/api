using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class ProfessorRepository
    {
        private readonly List<Professor> professors = new();

        public async Task<IEnumerable<Professor>> GetProfessor()
        {
            return await Task.FromResult(professors);
        }

        public async Task<Professor> GetProfessor(Guid id)
        {
            var professor = professors.Where(professor => professor.Id == id).SingleOrDefault();
            return await Task.FromResult(professor);
        }

        public async Task CreateProfessor(Professor professor)
        {
            professors.Add(professor);
            await Task.CompletedTask;
        }

        public async Task UpdateProfessor(Professor professor)
        {
            var index = professors.FindIndex(p => p.Id == professor.Id);
            professors[index] = professor;
            await Task.CompletedTask;
        }

        public async Task DeleteUser(Guid id)
        {
            var index = professors.FindIndex(p => p.Id == id);
            professors.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
