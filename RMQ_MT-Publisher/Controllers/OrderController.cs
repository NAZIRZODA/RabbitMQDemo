using Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace RMQ_MT_Publisher.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Publish(Order order)
    {
        await _publishEndpoint.Publish<Order>(order);
        return Ok();
    }
}