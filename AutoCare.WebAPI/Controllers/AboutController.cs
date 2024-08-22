using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCare.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IMediator _mediator;

    public AboutController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAbouts()
    {
        var result = await _mediator.Send(new GetAboutQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAbout(short id)
    {
        var result = await _mediator.Send(new GetAboutByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
    {
        var result = await _mediator.Send(createAboutCommand);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(DeleteAboutCommand deleteAboutCommand)
    {
        var result = await _mediator.Send(deleteAboutCommand);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
    {
        var result = await _mediator.Send(updateAboutCommand);
        return Ok(result);
    }
}
