using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Products
{
    public class GetAllProductQuery : IRequest<PaginationResponse<ProductViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, PaginationResponse<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _productRepository.SelectAll(request.Filters);

            var mapperItems = _mapper.Map<IEnumerable<ProductViewModel>>(queryResult.Data);

            return new PaginationResponse<ProductViewModel>(mapperItems, queryResult.TotalItems,
                queryResult.CurrentPage, request.Filters._size);
        }
    }
}

