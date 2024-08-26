using AutoCare.Application.Mediator.Commands.ServiceCommands;
using AutoCare.Application.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCare.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var result = await _mediator.Send(new GetServiceQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdService(short id)
    {
        var result = await _mediator.Send(new GetServiceByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
    {
        var result = await _mediator.Send(createServiceCommand);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteService(DeleteServiceCommand deleteServiceCommand)
    {
        var result = await _mediator.Send(deleteServiceCommand);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
    {
        var result = await _mediator.Send(updateServiceCommand);
        return Ok(result);
    }
}
