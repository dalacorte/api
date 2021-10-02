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
    }
}
