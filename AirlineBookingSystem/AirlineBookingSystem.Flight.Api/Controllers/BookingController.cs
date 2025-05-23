using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flight.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    //untuk konek ke MediatR
    private readonly IMediator _mediator;

    public FlightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFlights), new { id = id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var booking = await _mediator.Send(new GetAllFlightQuery());
        return Ok(booking);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(Guid id)
    {
        await _mediator.Send(new DeleteFlightCommand(id));
        return NoContent();
    }
}