﻿using Api.Dto;
using Api.Entities;
using Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<UserDTO>> GetUser()
        {
            var users = (await repository.GetUserAsync()).Select(user => user.AsDTO());

            return users;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = await repository.GetUserAsync(id);

            if(user is null)
                return NotFound();

            return user.AsDTO();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO userDTO)
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

            await repository.CreateUserAsync(user);

            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user.AsDTO());
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task <ActionResult> UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existingUser = await repository.GetUserAsync(id);

            if(existingUser is null)
                return NotFound();

            User updatedUser = existingUser with
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                ProfilePicture = userDTO.ProfilePicture,
                EmailVerified = userDTO.EmailVerified
            };

            await repository .UpdateUserAsync(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var existingUser = await repository.GetUserAsync(id);

            if (existingUser is null)
                return NotFound();

            await repository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
