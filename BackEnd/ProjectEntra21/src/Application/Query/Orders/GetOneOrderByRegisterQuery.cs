using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetOneOrderByRegisterQuery : IRequest<OrderViewModel>
    {
        public long RegisterEmployeer { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public long CodeProduct { get; set; }
    }

    public class GetOneOrderRequestHandler : IRequestHandler<GetOneOrderByRegisterQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOneOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOneOrderByRegisterQuery request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
            && x.CreateAt >= request.DateStart.Date && x.CreateAt < request.DateEnd.AddDays(1) && x.Product.Code == request.CodeProduct);

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
                Phase = order.CellEmployeer.Phase.ToString(),
                CreatAt = order.CreateAt.Date.ToShortDateString()
            };
        }
    }
}
