using MediatR;
using ProjectEntra21.src.Application.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Employeers
{
    public class DeleteOneEmployeerRequest : IRequest
    {
        public long Register { get; set; }
    }

    public class DeleteOneEmployeerRequestHandler : IRequestHandler<DeleteOneEmployeerRequest>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public DeleteOneEmployeerRequestHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<Unit> Handle(DeleteOneEmployeerRequest request, CancellationToken cancellationToken)
        {
            var deleteEmployeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            await _employeerRepository.Delete(deleteEmployeer);

            return Unit.Value;
        }
    }
}
