﻿using Application.Data;
using Domain.Customers;
using Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create;
internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer= await _context.Customers.FindAsync(
            new CustomerId(request.CustomerId));
        if (customer is null)
        {
            return;// TODO add some kind of validation here     
        }
        Order order = Order.Create(customer.Id);
        
        _context.Orders.Add(order);

        _context.SaveChangesAsync();

    }
}

