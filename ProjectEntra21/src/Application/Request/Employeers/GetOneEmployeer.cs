using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Employeers
{
    public class GetOneEmployeerRequest : IRequest<GetEmployeerViewModel>
    {
        public long Register { get; set; }
    }

    public class GetOneEmployeerRequestHandler : IRequestHandler<GetOneEmployeerRequest, GetEmployeerViewModel>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public GetOneEmployeerRequestHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<GetEmployeerViewModel> Handle(GetOneEmployeerRequest request, CancellationToken cancellationToken)
        {
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            return new GetEmployeerViewModel
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
