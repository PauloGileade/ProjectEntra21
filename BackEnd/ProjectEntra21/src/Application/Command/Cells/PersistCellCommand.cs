using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Cells
{
    public class PersistCellCommand : IRequest<Cell>
    {
        public int CodeCell { get; set; }
        public string StatusCell { get; set; }
    }

    public class PersistCellCommandHandler : IRequestHandler<PersistCellCommand, Cell>
    {
        private readonly ICellRepository _cellRepository;

        public PersistCellCommandHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<Cell> Handle(PersistCellCommand request, CancellationToken cancellationToken)
        {
            Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            if (cell == null)

                cell = new Cell();

            cell.CodeCell = request.CodeCell;
            cell.StatusCell = Enum.Parse<StatusCell>(request.StatusCell);

            await _cellRepository.InsertOrUpdate(cell);

            return cell;
        }
    }
}
