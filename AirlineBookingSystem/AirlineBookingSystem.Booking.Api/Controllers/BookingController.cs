using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Booking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    //untuk konek ke MediatR
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBookingById), new { id = id }, command);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBookingById(Guid id)
    {
        var booking = await _mediator.Send(new GetBookingQuery(id));
        return Ok(booking);
    }
}