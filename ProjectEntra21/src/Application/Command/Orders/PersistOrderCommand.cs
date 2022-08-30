using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Orders
{
    public class PersistOrderCommand : IRequest<Order>
    {
        public long RegisterEmployeer { get; set; }
        public long CodeProduct { get; set; }
        public int AmountEnter { get; set; }

    }

    public class PersistOrderCommandHandler : IRequestHandler<PersistOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICellEmployeerRepository _cellEmployeerRepository;
        private readonly IProductRepository _productRepository;

        public PersistOrderCommandHandler(IOrderRepository orderRepository, ICellEmployeerRepository cellEmployeerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cellEmployeerRepository = cellEmployeerRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> Handle(PersistOrderCommand request, CancellationToken cancellationToken)
        {
                CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Employeer.Register == request.RegisterEmployeer);

            if (cellEmployeer == null)
                return null;

            Product product = await _productRepository.SelectOne(x => x.Code == request.CodeProduct);

            if (product == null)
                return null;


            if (request.AmountEnter == 0)
                return null;


            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
                && x.Product.Code == request.CodeProduct && x.CreateAt >= DateTime.Now.Date
                    && x.CreateAt < DateTime.Now.Date.AddDays(1));

            if (order == null)

                order = new Order();

            order.CellEmployeer = cellEmployeer;
            order.Product = product;
            order.AmountEnter += request.AmountEnter;

            await _orderRepository.InsertOrUpdate(order);

            return order;
        }
    }
}
