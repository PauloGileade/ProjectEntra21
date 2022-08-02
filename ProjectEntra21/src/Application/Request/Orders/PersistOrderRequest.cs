using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Orders
{
    public class PersistOrderRequest : IRequest<Order>
    {
        public DateTime Data { get; set; } 
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }

    public class PersistOrderRequestHandler : IRequestHandler<PersistOrderRequest, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public PersistOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(PersistOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.Data == request.Data);

            if (order == null)

                order = new Order();

            order.Data = request.Data;
            order.AmountEnter = request.AmountEnter;
            order.AmountFinished = request.AmountFinished;

            await _orderRepository.InsertOrUpdate(order);

            return order;
        }
    }
}
