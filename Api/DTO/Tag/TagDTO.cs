using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Tag
{
    public record TagDTO
    {
        [Required]
        public IEnumerable<String> Tags { get; init; }
    }
}
