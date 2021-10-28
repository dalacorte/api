﻿using System;
using System.Collections.Generic;

namespace Api.Entities
{
    public record Org
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public User Administrator { get; init; }
        public IEnumerable<User> Moderator { get; init; }  
        public IEnumerable<User> Users { get; init; }    
        public IEnumerable<Post> Posts { get; init; }
        public bool Private { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
