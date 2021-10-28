using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Org
{
    public record UpdateUserOrgDTO
    {
        public IEnumerable<User> Users { get; init; }
    }
}
