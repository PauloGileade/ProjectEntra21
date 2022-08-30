using MediatR;
using ProjectEntra21.src.Application.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Cells
{
    public class DeleteOneCellCommand : IRequest
    {
        public int CodeCell { get; set; }
    }

    public class DeleteOneCellCommandHandler : IRequestHandler<DeleteOneCellCommand>
    {
        private readonly ICellRepository _cellRepository;

        public DeleteOneCellCommandHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<Unit> Handle(DeleteOneCellCommand request, CancellationToken cancellationToken)
        {
            var deleteCell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            await _cellRepository.Delete(deleteCell);

            return Unit.Value;
        }
    }
}
