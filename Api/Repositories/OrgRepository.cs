using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class OrgRepository : IOrgRepository
    {
        private readonly List<Org> orgs = new();

        public async Task<IEnumerable<Org>> GetOrg()
        {
            return await Task.FromResult(orgs);
        }

        public async Task<Org> GetOrg(Guid id)
        {
            var org = orgs.Where(org => org.Id == id).SingleOrDefault();
            return await Task.FromResult(org);
        }

        public async Task CreateOrg(Org org)
        {
            orgs.Add(org);
            await Task.CompletedTask;
        }

        public async Task UpdateOrg(Org org)
        {
            var index = orgs.FindIndex(o => o.Id == org.Id);
            orgs[index] = org;
            await Task.CompletedTask;
        }

        public async Task UpdateUserOrg(Org org)
        {
            var index = orgs.FindIndex(u => u.Id == org.Id);
            orgs[index] = org;
            await Task.CompletedTask;
        }

        public async Task UpdateModeratorOrg(Org org)
        {
            var index = orgs.FindIndex(m => m.Id == org.Id);
            orgs[index] = org;
            await Task.CompletedTask;
        }

        public async Task DeleteOrg(Guid id)
        {
            var index = orgs.FindIndex(o => o.Id == id);
            orgs.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
