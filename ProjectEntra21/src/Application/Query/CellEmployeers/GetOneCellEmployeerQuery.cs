using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.CellEmployeers
{
    public class GetOneCellEmployeerQuery : IRequest<PaginationResponse<CellEmployeerViewModel>>
    {
        public long CodeCell { get; set; }
        public DateTime Date { get; set; }
        public FilterBase Filters { get; set; }
    }

    public class GetOneCellEmployeerRequestHandler : IRequestHandler<GetOneCellEmployeerQuery, PaginationResponse<CellEmployeerViewModel>>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;
        private readonly IMapper _mapper;

        public GetOneCellEmployeerRequestHandler(ICellEmployeerRepository cellEmployeerRepository, IMapper mapper)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<CellEmployeerViewModel>> Handle(GetOneCellEmployeerQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _cellEmployeerRepository.SelectMore(request.CodeCell, request.Date, request.Filters);

            var mappedItems = _mapper.Map<IEnumerable<CellEmployeerViewModel>>(queryResult.Data);

            return new PaginationResponse<CellEmployeerViewModel>(mappedItems, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}
