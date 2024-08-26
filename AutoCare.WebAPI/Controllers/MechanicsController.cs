using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Queries.MechanicServicesQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCare.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MechanicsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MechanicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMechanics()
    {
        var result = await _mediator.Send(new GetMechanicQuery());
        return Ok(result);
    }

    [HttpGet("GetMechanicServices")]
    public async Task<IActionResult> GetMechanicServices()
    {
        var result = await _mediator.Send(new GetMechanicServicesQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdMechanic(short id)
    {
        var result = await _mediator.Send(new GetMechanicByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMechanic(CreateMechanicCommand createMechanicCommand)
    {
        var result = await _mediator.Send(createMechanicCommand);
        return Ok(result);
    }
    [HttpPost("CreateMechanicServices")]
    public async Task<IActionResult> CreateMechanicServices(CreateMechanicServicesCommand createMechanicServiceCommand)
    {
        var result = await _mediator.Send(createMechanicServiceCommand);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteMechanic(DeleteMechanicCommand deleteMechanicCommand)
    {
        var result = await _mediator.Send(deleteMechanicCommand);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateMechanic(UpdateMechanicCommand updateMechanicCommand)
    {
        var result = await _mediator.Send(updateMechanicCommand);
        return Ok(result);
    }
}
