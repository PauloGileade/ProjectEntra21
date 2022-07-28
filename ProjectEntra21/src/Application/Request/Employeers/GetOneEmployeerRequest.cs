using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.Request.Employeers.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Employeers
{
    public class GetOneEmployeerRequest : IRequest<GetOneEmployeerViewModel>
    {
        public long Register { get; set; }
    }

    public class GetOneEmployeerRequestHandler : IRequestHandler<GetOneEmployeerRequest, GetOneEmployeerViewModel>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public GetOneEmployeerRequestHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<GetOneEmployeerViewModel> Handle(GetOneEmployeerRequest request, CancellationToken cancellationToken)
        {
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            return new GetOneEmployeerViewModel
            {
                Register = employeer.Register,
                Name = employeer.Name,
                Document = employeer.Document,
                BirthDate = employeer.BirthDate,
                Office = employeer.Office,
                LevelEmployeer = employeer.LevelEmployeer,
            };
        }
    }
}
