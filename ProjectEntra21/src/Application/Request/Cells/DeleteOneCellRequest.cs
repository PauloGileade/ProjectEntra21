using MediatR;
using ProjectEntra21.src.Application.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Cells
{
    public class DeleteOneCellRequest : IRequest
    {
        public int CodeCell { get; set; }
    }

    public class DeleteOneCellRequestHandler : IRequestHandler<DeleteOneCellRequest>
    {
        private readonly ICellRepository _cellRepository;

        public DeleteOneCellRequestHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<Unit> Handle(DeleteOneCellRequest request, CancellationToken cancellationToken)
        {
            var deleteCell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            await _cellRepository.Delete(deleteCell);

            return Unit.Value;
        }
    }
}
