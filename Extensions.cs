using Api.Dto;
using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class Extensions
    {
        public static UserDTO AsDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Name,
                Password = user.Password,
                ProfilePicture = user.ProfilePicture,
                EmailVerified = user.EmailVerified,
                CreatedDate = user.CreatedDate
            };
        }
    }
}
