using Domain.Customers;
using Domain.Products;
using System.Collections.Generic;

namespace Domain.Orders;

public class Order
{
    private Order()
    {
    }
    private readonly HashSet<LineItem> _lineItems = new();
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyCollection<LineItem> LineItem => _lineItems.ToList();

    public static Order Create(CustomerId CustomerId)
    {
        Order order = new Order()
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = CustomerId
        };
        return order;
    }

    public void AddLineItem(ProductId ProductId, Money Price)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()),
            Id,
            ProductId,
            Price);//catching a point in time whrn product is price is price

        _lineItems.Add(lineItem);
    }

}
