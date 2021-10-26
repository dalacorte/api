using Api.Dto;
using Api.DTO.Tag;
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
    [Route("tags")]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository repository;

        public TagsController(ITagRepository tagRepository)
        {
            repository = tagRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<TagDTO>> GetTag()
        {
            var tags = (await repository.GetTag()).Select(tag => tag.AsTagDTO());

            return tags;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TagDTO>> CreateTag(TagDTO tagDTO)
        {
            Tag tag = new()
            {
                Tags = tagDTO.Tags
            };

            await repository.CreateTag(tag);

            return CreatedAtAction(nameof(CreateTag), new { tag = tag.Tags }, tag.AsTagDTO());
        }
    }
}
