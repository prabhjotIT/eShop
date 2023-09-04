using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.GetOrder;
internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderResponse>
{
    private readonly IApplicationDbContext _context;
    public GetOrderQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        //var orderResponse = await _context
        //    .Orders
        //    .Where(o => o.Id == new Domain.Orders.OrderId(request.OrderID))
        //    .Select(order => new OrderResponse(
        //        order.Id.Value,
        //        order.CustomerId.Value,
        //        order.LineItems
        //        .Select(
        //            li => new LineItemResponse(
        //            li.Id.Value,
        //            li.Price.Amount
        //            )).ToList()))
        //    .SingleAsync(cancellationToken);

        var orderSummaries = await _context
           .Database
           .SqlQuery<OrderSummary>(@$"
            SELECT o.Id AS ORDERID, o.CustomerId , li.LineItemId , li.Price_Amount AS LINEITEMPRICE
            FROM Orders AS o 
            JOIN LineItems AS LI ON li.OrderId == o.Id
            WHERE o.id = {request.OrderId}")
           .ToListAsync(cancellationToken);
        var orderResponse = orderSummaries.
            GroupBy(o => o.OrderId)
            .Select(grp => new OrderResponse(
                grp.Key,
                grp.First().CustomerId,
                grp.Select(o => new LineItemResponse(
                    o.LineItemId,
                    o.Price
                    )).ToList()
                ))
            .Single();

        return orderResponse;
    }
    public record OrderSummary(
        Guid OrderId,
        Guid CustomerId,
        Guid LineItemId,
        decimal Price);
}

