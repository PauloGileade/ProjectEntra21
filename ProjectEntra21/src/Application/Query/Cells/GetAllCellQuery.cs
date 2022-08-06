using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Cells
{
    public class GetAllCellQuery : IRequest<PaginationResponse<CellViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllCellQueryHandler : IRequestHandler<GetAllCellQuery, PaginationResponse<CellViewModel>>
    {
        private readonly ICellRepository _cellRepository;
        private readonly IMapper _mapper;

        public GetAllCellQueryHandler(ICellRepository cellRepository, IMapper mapper)
        {
            _cellRepository = cellRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<CellViewModel>> Handle(GetAllCellQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _cellRepository.SelectAll(request.Filters);
            var mappedItems = _mapper.Map<IEnumerable<CellViewModel>>(queryResult.Data);

            return new PaginationResponse<CellViewModel>(mappedItems, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}
