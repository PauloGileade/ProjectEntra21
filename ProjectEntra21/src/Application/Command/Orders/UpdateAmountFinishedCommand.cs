using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Command.Orders
{
    public class UpdateAmountFinishedCommand : IRequest<Order>
    {
        public long RegisterEmployeer { get; set; }
        public long CodeProduct { get; set; }
    }

    public class UpadateAmountFinishedCommandHandler : IRequestHandler<UpdateAmountFinishedCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public UpadateAmountFinishedCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(UpdateAmountFinishedCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
               && x.Product.Code == request.CodeProduct && x.CreateAt >= DateTime.Now.Date.Date
                    && x.CreateAt < DateTime.Now.Date.Date.AddDays(1));

            if (order == null)
                return null;


            order.AmountFinished = order.AmountFinished == null ? 1: order.AmountFinished + 1 ;

            await _orderRepository.Update(order);

            return order;
        }
    }
}
