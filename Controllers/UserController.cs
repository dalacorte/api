using Api.Dto;
using Api.Entities;
using Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = new UserRepository();
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<UserDTO> GetUser()
        {
            var users = userRepository.GetUser().Select(user => user.AsDTO());

            return users;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<UserDTO> GetUser(Guid id)
        {
            var user = userRepository.GetUser(id);

            if(user is null)
                return NotFound();

            return user.AsDTO();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDTO> CreateUser(CreateUserDTO userDTO)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Email = userDTO.Email,
                Name = userDTO.Name,
                ProfilePicture = userDTO.ProfilePicture,
                EmailVerified = userDTO.EmailVerified,
                CreatedDate = DateTimeOffset.UtcNow
            };

            userRepository.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.AsDTO());
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existingUser = userRepository.GetUser(id);

            if(existingUser is null)
                return NotFound();

            User updatedUser = existingUser with
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                ProfilePicture = userDTO.ProfilePicture,
                EmailVerified = userDTO.EmailVerified
            };

            userRepository.UpdateUser(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public ActionResult DeleteUser(Guid id)
        {
            var existingUser = userRepository.GetUser(id);

            if (existingUser is null)
                return NotFound();

            userRepository.DeleteUser(id);

            return NoContent();
        }
    }
}
