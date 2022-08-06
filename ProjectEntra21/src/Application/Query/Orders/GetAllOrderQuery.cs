using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetAllOrderQuery : IRequest<PaginationResponse<OrderViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, PaginationResponse<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<OrderViewModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _orderRepository.SelectAll(request.Filters);

            var mappedItems = _mapper.Map<IEnumerable<OrderViewModel>>(queryResult.Data);

            return new PaginationResponse<OrderViewModel>(mappedItems, queryResult.TotalItems,
                queryResult.CurrentPage, request.Filters._size);
        }
    }
}
