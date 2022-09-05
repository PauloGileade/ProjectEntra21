using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Command.Orders
{
    public class UpdateAmountFinishedCommand : IRequest<Order>
    {
        public long RegisterEmployeer { get; set; }
        public long CodeProduct { get; set; }
        public string Phase { get; set; }
        public long Cell { get; set; }
    }

    public class UpadateAmountFinishedCommandHandler : IRequestHandler<UpdateAmountFinishedCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITotalPartialRepository _totalPartialRepository;

        public UpadateAmountFinishedCommandHandler(IOrderRepository orderRepository, ITotalPartialRepository totalPartialRepository)
        {
            _orderRepository = orderRepository;
            _totalPartialRepository = totalPartialRepository;
        }

        public async Task<Order> Handle(UpdateAmountFinishedCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
               && x.Product.Code == request.CodeProduct && x.CreateAt >= DateTime.Now.Date.Date
                    && x.CreateAt < DateTime.Now.Date.Date.AddDays(1) && x.CellEmployeer.Phase == Enum.Parse<PhaseCell>(request.Phase) && x.CellEmployeer.Cell.CodeCell == request.Cell);

            if (order == null)
                return null;


            order.AmountFinished = order.AmountFinished == null ? 1 : order.AmountFinished + 1;

            await _orderRepository.Update(order);





            if (PhaseCell.Inicial == Enum.Parse<PhaseCell>(request.Phase) || PhaseCell.Intermediaria == Enum.Parse<PhaseCell>(request.Phase))
            {
                TotalPartial totalFinishedPartial = await _totalPartialRepository.SelectTotalPartial(int.Parse(request.Phase));
                totalFinishedPartial.Total = totalFinishedPartial.Total == 0 ? 1 : totalFinishedPartial.Total + 1;

                await _totalPartialRepository.Update(totalFinishedPartial);
            }



            return order;
        }
    }
}
