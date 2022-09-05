using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
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
            var mappedItems = _mapper.Map<IEnumerable<CellEmployeer>>(queryResult.Data);

            List<CellEmployeerViewModel> list = new();

            foreach (var mappedItem in mappedItems)
            {
                list.Add(new CellEmployeerViewModel
                {
                    RegisterEmployeer = mappedItem.Employeer.Register,
                    NameEmployeer = mappedItem.Employeer.Name,
                    Office = mappedItem.Employeer.Office,
                    LevelEmployeer = mappedItem.Employeer.LevelEmployeer.ToString(),
                    Phase = mappedItem.Phase.ToString()});
            }
            return new PaginationResponse<CellEmployeerViewModel>(list, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}
