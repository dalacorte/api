using Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IOrgRepository
    {
        Task<Org> GetOrg(Guid id);
        Task<IEnumerable<Org>> GetOrg();
        Task CreateOrg(Org org);
        Task UpdateOrg(Org org);
        Task UpdateModeratorOrg(Org org);
        Task UpdateUserOrg(Org org);
        Task DeleteOrg(Guid id);
    }
}