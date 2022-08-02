using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class GetOneCellEmployeerRequest : IRequest<GetCellEmployeerViewModel>
    {
        public int Code { get; set; }
    }

    public class GetOneCellEmployeerRequestHandler : IRequestHandler<GetOneCellEmployeerRequest, GetCellEmployeerViewModel>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public GetOneCellEmployeerRequestHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<GetCellEmployeerViewModel> Handle(GetOneCellEmployeerRequest request, CancellationToken cancellationToken)
        {
            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Code == request.Code);

            return new GetCellEmployeerViewModel
            {
                Code = cellEmployeer.Code,
                Employeers = cellEmployeer.Employeers,
                Cell = cellEmployeer.Cell
            };
        }
    }
}
