using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public record Post
    {
        public Guid Id { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public Professor Author { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public string Attachment { get; init; }
        public IEnumerable<Tag> Tag { get; init; }
    }
}
