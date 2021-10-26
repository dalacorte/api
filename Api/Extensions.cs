using Api.Dto;
using Api.DTO.Tag;
using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class Extensions
    {
        public static UserDTO AsUserDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                ProfilePicture = user.ProfilePicture,
                EmailVerified = user.EmailVerified,
                CreatedDate = user.CreatedDate
            };
        }

        public static ProfessorDTO AsProfessorDTO(this Professor professor)
        {
            return new ProfessorDTO
            {
                Id = professor.Id,
                Email = professor.Email,
                Name = professor.Name,
                Username = professor.Username,
                Password = professor.Password,
                Post = professor.Post,
                ProfilePicture = professor.ProfilePicture,
                EmailVerified = professor.EmailVerified,
                CanCreate = professor.CanCreate,
                CreatedDate = professor.CreatedDate
            };
        }

        public static TagDTO AsTagDTO(this Tag tag)
        {
            return new TagDTO
            {
                Tags = tag.Tags
            };
        }
    }
}
