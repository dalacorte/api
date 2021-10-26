using Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTag();
        Task CreateTag(Tag tag);
    }
}