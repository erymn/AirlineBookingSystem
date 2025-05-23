using AirlineBookingSystem.Payment.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Payment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    //untuk konek ke MediatR
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ProcessPayment), new { id = id }, command);
    }

    [HttpDelete("refund/{id}")]
    public async Task<IActionResult> RefundPayment(Guid id)
    {
        await _mediator.Send(new RefundPaymentCommand(id));
        return NoContent();
    }
}