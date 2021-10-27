using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Org
{
    public record CreateOrgDTO
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public User Administrator { get; init; }
        [Required]
        public bool Private { get; init; }
        [Required]
        public DateTimeOffset CreatedDate { get; init; }
    }
}
