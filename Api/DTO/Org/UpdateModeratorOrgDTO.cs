using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Org
{
    public record UpdateModeratorOrgDTO
    {
        public IEnumerable<User> Moderator { get; init; }
    }
}
