using Application.Orders.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

    public class OrderController: ControllerBase
    {
    private readonly IMediator mediator;

    public OrderController(IMediator mediator)
    {

    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand request)
    {
        var order = await request;
        return Ok(order);
    }
    }

