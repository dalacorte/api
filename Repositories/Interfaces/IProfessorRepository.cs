using Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IProfessorRepository
    {
        Task<Professor> GetProfessor(Guid id);
        Task<IEnumerable<Professor>> GetProfessor();
        Task CreateProfessor(Professor professor);
        Task UpdateProfessor(Professor professor);
        Task DeleteProfessor(Guid id);
    }
}