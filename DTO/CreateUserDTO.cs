﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto
{
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; init; }
        [Required]
        public string Name { get; init; }
        public string ProfilePicture { get; init; }
        [Required]
        public bool EmailVerified { get; init; }
    }
}
