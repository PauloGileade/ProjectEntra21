using MediatR;
using ProjectEntra21.src.Application.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Employeers
{
    public class DeleteOneEmployeerCommand : IRequest
    {
        public long Register { get; set; }
    }

    public class DeleteOneEmployeerCommandHandler : IRequestHandler<DeleteOneEmployeerCommand>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public DeleteOneEmployeerCommandHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<Unit> Handle(DeleteOneEmployeerCommand request, CancellationToken cancellationToken)
        {
            var deleteEmployeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            await _employeerRepository.Delete(deleteEmployeer);

            return Unit.Value;
        }
    }
}
