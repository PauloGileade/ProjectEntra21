using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class DeleteOneCellEmployeerRequest : IRequest
    {
        public int Code { get; set; }
    }

    public class DeleteOndeCellEmployeerRequestHandler : IRequestHandler<DeleteOneCellEmployeerRequest>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public DeleteOndeCellEmployeerRequestHandler(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        public async Task<Unit> Handle(DeleteOneCellEmployeerRequest request, CancellationToken cancellationToken)
        {
            var deleteCellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Code == request.Code);

            await _cellEmployeerRepository.Delete(deleteCellEmployeer);

            return Unit.Value;
        }
    }
}
