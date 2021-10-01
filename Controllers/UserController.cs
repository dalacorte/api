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
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<User> GetUser()
        {
            var users = _userRepository.GetUser();
            return users;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public User GetUser(Guid id)
        {
            var users = _userRepository.GetUser(id);
            return users;
        }
    }
}
