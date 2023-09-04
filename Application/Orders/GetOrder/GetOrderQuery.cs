using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.GetOrder;
public record GetOrderQuery(Guid OrderId):IRequest<OrderResponse>;
