using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetOneOrderQuery : IRequest<OrderViewModel>
    {
        public long RegisterEmployeer { get; set; }
        public DateTime Date { get; set; }
        public long CodeProduct { get; set; }
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
            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
            && x.CreateAt >= request.Date.Date && x.CreateAt < request.Date.AddDays(1) && x.Product.Code == request.CodeProduct);

            if (order == null) 
                return null;


            return new OrderViewModel
            {
                CodeCell = order.CellEmployeer.Cell.CodeCell,
                CodeProduct = order.Product.Code,
                NameProduct = order.Product.Name,
                RegisterEmployeer = order.CellEmployeer.Employeer.Register,
                NameEmployeer = order.CellEmployeer.Employeer.Name,
                AmountEnter = order.AmountEnter,
                AmountFinished = order.AmountFinished,
                CreatAt = order.CreateAt
            };
        }
    }
}
