using Api.Dto;
using Api.DTO.Org;
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
    [Route("orgs")]
    public class OrgsController : ControllerBase
    {
        private readonly IOrgRepository repository;

        public OrgsController(IOrgRepository orgRepository)
        {
            repository = orgRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<OrgDTO>> GetOrg()
        {
            var orgs = (await repository.GetOrg()).Select(org => org.AsOrgDTO());

            return orgs;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<OrgDTO>> GetOrg(Guid id)
        {
            var org = await repository.GetOrg(id);

            if (org is null)
                return NotFound();

            return org.AsOrgDTO();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<OrgDTO>> CreateOrg(CreateOrgDTO orgDTO)
        {
            Org org = new()
            {
                Id = Guid.NewGuid(),
                Name = orgDTO.Name,
                Administrator = orgDTO.Administrator,
                Private = false,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateOrg(org);

            return CreatedAtAction(nameof(CreateOrg), new { id = org.Id }, org.AsOrgDTO());
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateOrg(Guid id, UpdateOrgDTO orgDTo)
        {
            var existingOrg = await repository.GetOrg(id);

            if (existingOrg is null)
                return NotFound();

            Org updatedOrg = existingOrg with
            {
                Name = orgDTo.Name,
                Administrator = orgDTo.Administrator,
                Private = orgDTo.Private
            };

            await repository.UpdateOrg(updatedOrg);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteOrg(Guid id)
        {
            var existingOrg = await repository.GetOrg(id);

            if (existingOrg is null)
                return NotFound();

            await repository.DeleteOrg(id);

            return NoContent();
        }
    }
}
