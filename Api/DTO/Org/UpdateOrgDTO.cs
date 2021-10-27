using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Org
{
    public record UpdateOrgDTO
    {
        public string Name { get; init; }
        public User Administrator { get; init; }
        public bool Private { get; init; }
    }
}
