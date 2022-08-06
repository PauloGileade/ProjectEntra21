using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.CellEmployeers
{
    public class GetOneCellEmployeerQuery : IRequest<CellEmployeerViewModel>
    {
        public long Code { get; set; }
    }

    public class GetOneCellEmployeerRequestHandler : IRequestHandler<GetOneCellEmployeerQuery, CellEmployeerViewModel>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public GetOneCellEmployeerRequestHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<CellEmployeerViewModel> Handle(GetOneCellEmployeerQuery request, CancellationToken cancellationToken)
        {
            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Code == request.Code);

            return new CellEmployeerViewModel
            {
                Code = cellEmployeer.Code,
                CodeCell = cellEmployeer.CodeCell,
                RegisterEmployeer = cellEmployeer.RegisterEmployeer
            };
        }
    }
}
