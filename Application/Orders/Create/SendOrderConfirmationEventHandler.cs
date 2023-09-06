
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create;

internal sealed class SendOrderConfirmationEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly Logger<SendOrderConfirmationEventHandler> _logger;
    public SendOrderConfirmationEventHandler(Logger<SendOrderConfirmationEventHandler> logger)
    {
            _logger = logger;   
    }
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending order confirmation {@OrderId}",notification.OrderId);

        await Task.Delay(2000,cancellationToken);

        _logger.LogInformation(" order sent {@OrderId}",notification.OrderId);
              
    }
}

