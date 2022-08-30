using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class DeleteOneCellEmployeerCommand : IRequest
    {
        public int Code { get; set; }
    }

    public class DeleteOndeCellEmployeerCommandHandler : IRequestHandler<DeleteOneCellEmployeerCommand>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public DeleteOndeCellEmployeerCommandHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<Unit> Handle(DeleteOneCellEmployeerCommand request, CancellationToken cancellationToken)
        {
            var deleteCellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Code == request.Code);

            await _cellEmployeerRepository.Delete(deleteCellEmployeer);

            return Unit.Value;
        }
    }
}
