using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create;
internal class CreatePaymentRequestEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly Logger<CreatePaymentRequestEventHandler> _logger;
    public CreatePaymentRequestEventHandler(Logger<CreatePaymentRequestEventHandler> logger)
    {
            _logger = logger;   
    }
    public  async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting payment request {@OrderId}", notification.OrderId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation(" payment requested {@OrderId}", notification.OrderId);
    }
}

