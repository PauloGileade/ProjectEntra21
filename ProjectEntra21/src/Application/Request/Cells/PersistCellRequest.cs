using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Cells
{
    public class PersistCellRequest : IRequest<Cell>
    {
        public int CodeCell { get; set; }
        public StatusCell StatusCell { get; set; }
    }

    public class PersistCellRequestHandler : IRequestHandler<PersistCellRequest, Cell>
    {
        private readonly ICellRepository _cellRepository;

        public PersistCellRequestHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<Cell> Handle(PersistCellRequest request, CancellationToken cancellationToken)
        {
            Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            if (cell == null)

                cell = new Cell();

            cell.CodeCell = request.CodeCell;
            cell.StatusCell = request.StatusCell;

            await _cellRepository.InsertOrUpdate(cell);

            return cell;
        }
    }
}
