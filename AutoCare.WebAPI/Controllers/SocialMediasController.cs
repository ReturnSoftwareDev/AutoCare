using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Queries.SocialMediaQueries;
using AutoCare.Application.Validator.SocialMediaValidator;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSocialMedias()
        {
            var result = await _mediator.Send(new GetSocialMediasQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSocialMedia(short id)
        {
            var result = await _mediator.Send(new GetByIdSocialMediaQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand)
        {
            var result = await _mediator.Send(createSocialMediaCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            var result = await _mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            var result = await _mediator.Send(updateSocialMediaCommand);
            return Ok(result);
        }

    }
}
