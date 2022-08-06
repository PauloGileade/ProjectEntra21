using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.CellEmployeers
{
    public class GetAllCellEmployeerQuery : IRequest<PaginationResponse<CellEmployeerViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllCellEmployeerQueryHandler : IRequestHandler<GetAllCellEmployeerQuery, PaginationResponse<CellEmployeerViewModel>>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;
        private readonly IMapper _mapper;

        public GetAllCellEmployeerQueryHandler(ICellEmployeerRepository cellEmployeerRepository, IMapper mapper)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<CellEmployeerViewModel>> Handle(GetAllCellEmployeerQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _cellEmployeerRepository.SelectAll(request.Filters);
            var mappedItems = _mapper.Map<IEnumerable<CellEmployeerViewModel>>(queryResult.Data);

            return new PaginationResponse<CellEmployeerViewModel>(mappedItems, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}
