using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Orders
{
    public class PersistOrderCommand : IRequest<Order>
    {
        public long Code { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public Employeer Employeer { get; set; }
        public Product Product { get; set; }
        public Cell Cell { get; set; }
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }

    public class PersistOrderCommandHandler : IRequestHandler<PersistOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public PersistOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(PersistOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.Code == request.Code);

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
