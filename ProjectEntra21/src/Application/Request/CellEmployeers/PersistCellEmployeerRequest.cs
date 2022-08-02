using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class PersistCellEmployeerRequest : IRequest<CellEmployeer>
    {
        public int Code { get; set; }
        public IList<Employeer> Employeers { get; set; } = new List<Employeer>();
        public Cell Cell{ get; set; }
    }

    public class PersistEmployeerResquestHandler : IRequestHandler<PersistCellEmployeerRequest, CellEmployeer>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public PersistEmployeerResquestHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<CellEmployeer> Handle(PersistCellEmployeerRequest request, CancellationToken cancellationToken)
        {
            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Code == request.Code);

            if (cellEmployeer == null)

                cellEmployeer = new CellEmployeer();

            cellEmployeer.Code = request.Code;
            cellEmployeer.Cell = request.Cell;
            cellEmployeer.Employeers = request.Employeers;

            await _cellEmployeerRepository.InsertOrUpdate(cellEmployeer);

            return cellEmployeer;
        }
    }
}
