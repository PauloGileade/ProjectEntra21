using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetOneOrderQuery : IRequest<OrderViewModel>
    {
        public long Code { get; set; }
    }

    public class GetOneOrderRequestHandler : IRequestHandler<GetOneOrderQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOneOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOneOrderQuery request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.Code == request.Code);

            return new OrderViewModel
            {
                Code = order.Code,
                Data = order.Data,
                Employeer = order.Employeer,
                Products = order.Product,
                AmountEnter = order.AmountEnter,
                AmountFinished = order.AmountFinished,
            };
        }
    }
}
