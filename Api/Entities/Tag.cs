using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public record Tag
    {
        public IEnumerable<string> Tags { get; init; }
    }
}
