using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class TagRepository
    {
        private readonly List<Tag> tags = new();

        public async Task<IEnumerable<Tag>> GetTag()
        {
            return await Task.FromResult(tags);
        }

        public async Task CreateTag(Tag tag)
        {
            tags.Add(tag);
            await Task.CompletedTask;
        }
    }
}
