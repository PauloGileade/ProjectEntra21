using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Orders
{
    public class GetOneOrderRequest : IRequest<GetOrderViewModel>
    {
        public long Code { get; set; }
    }

    public class GetOneOrderRequestHandler : IRequestHandler<GetOneOrderRequest, GetOrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOneOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderViewModel> Handle(GetOneOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.Code == request.Code);

            return new GetOrderViewModel
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
