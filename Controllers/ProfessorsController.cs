using Api.Dto;
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
    [Route("professors")]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorRepository repository;

        public ProfessorsController(IProfessorRepository professorRepository)
        {
            repository = professorRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProfessorDTO>> GetProfessor()
        {
            var professors = (await repository.GetProfessor()).Select(professor => professor.AsProfessorDTO());

            return professors;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProfessorDTO>> GetProfessor(Guid id)
        {
            var professor = await repository.GetProfessor(id);

            if (professor is null)
                return NotFound();

            return professor.AsProfessorDTO();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ProfessorDTO>> CreateProfessor(CreateProfessorDTO professorDTO)
        {
            Professor professor = new()
            {
                Id = Guid.NewGuid(),
                Email = professorDTO.Email,
                Name = professorDTO.Name,
                Username = professorDTO.Username,
                Password = professorDTO.Password,
                Post = professorDTO.Post,
                ProfilePicture = professorDTO.ProfilePicture,
                EmailVerified = professorDTO.EmailVerified,
                CanCreate = true,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateProfessor(professor);

            return CreatedAtAction(nameof(CreateProfessor), new { id = professor.Id }, professor.AsProfessorDTO());
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateProfessor(Guid id, UpdateProfessorDTO professorDTO)
        {
            var existingProfessor = await repository.GetProfessor(id);

            if (existingProfessor is null)
                return NotFound();

            Professor updatedProfessor = existingProfessor with
            {
                Email = professorDTO.Email,
                Name = professorDTO.Name,
                Password = professorDTO.Password,
                ProfilePicture = professorDTO.ProfilePicture,
                EmailVerified = professorDTO.EmailVerified
            };

            await repository.UpdateProfessor(updatedProfessor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteProfessor(Guid id)
        {
            var existingProfessor = await repository.GetProfessor(id);

            if (existingProfessor is null)
                return NotFound();

            await repository.DeleteProfessor(id);

            return NoContent();
        }
    }
}
