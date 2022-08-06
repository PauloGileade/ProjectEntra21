using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class PersistCellEmployeerCommand : IRequest<CellEmployeer>
    {
        public int CodeCell { get; set; }
        public long RegisterEmployeer { get; set; }
    }

    public class PersistEmployeerCommandHandler : IRequestHandler<PersistCellEmployeerCommand, CellEmployeer>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public PersistEmployeerCommandHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<CellEmployeer> Handle(PersistCellEmployeerCommand request, CancellationToken cancellationToken)
        {
            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.CodeCell == request.CodeCell
                && x.RegisterEmployeer == request.RegisterEmployeer);

            if (cellEmployeer == null)

                cellEmployeer = new CellEmployeer();

            cellEmployeer.CodeCell = request.CodeCell;
            cellEmployeer.RegisterEmployeer = request.RegisterEmployeer;

            await _cellEmployeerRepository.InsertOrUpdate(cellEmployeer);

            return cellEmployeer;
        }
    }
}
