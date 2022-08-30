using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetAllOrderByCodecellQuery : IRequest<PaginationResponse<OrderViewModel>>
    {
        public long CodeCell { get; set; }
        public DateTime Date { get; set; }
        public FilterBase Filters { get; set; }
    }

    public class GetAllOrderByCodecellQueryHandler : IRequestHandler<GetAllOrderByCodecellQuery, PaginationResponse<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderByCodecellQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<OrderViewModel>> Handle(GetAllOrderByCodecellQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _orderRepository.SelectAllByCodecell(request.CodeCell, request.Date, request.Filters);
            var mappedItems = _mapper.Map<IEnumerable<Order>>(queryResult.Data);

            List<OrderViewModel> list = new();

            foreach (var mappedItem in mappedItems)
            {
                list.Add(new OrderViewModel
                {
                    CodeCell = mappedItem.CellEmployeer.Cell.CodeCell,
                    CodeProduct = mappedItem.Product.Code,
                    NameProduct = mappedItem.Product.Name,
                    RegisterEmployeer = mappedItem.CellEmployeer.Employeer.Register,
                    NameEmployeer = mappedItem.CellEmployeer.Employeer.Name,
                    AmountEnter = mappedItem.AmountEnter,
                    AmountFinished = mappedItem.AmountFinished,
                    CreatAt = mappedItem.CreateAt.Date.ToShortDateString(),
                });
            }
            return new PaginationResponse<OrderViewModel>(list, queryResult.TotalItems,
                  queryResult.CurrentPage, request.Filters._size);
        }
    }
}
