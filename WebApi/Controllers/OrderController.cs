using Application.Orders.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
    public class OrderController:ControllerBase
    {
    private readonly IMediator _mediatoR;
    public OrderController(IMediator mediatoR)
    {
        this._mediatoR = mediatoR;
    }
    
    [Route("[Controller]")]
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand request)
    {
       await _mediatoR.Send(request);
        return Ok();
    }

}

