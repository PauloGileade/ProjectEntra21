using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Employeers
{
    public class GetOneEmployeerQuery : IRequest<EmployeerViewModel>
    {
        public long Register { get; set; }
    }

    public class GetOneEmployeerRequestHandler : IRequestHandler<GetOneEmployeerQuery, EmployeerViewModel>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public GetOneEmployeerRequestHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<EmployeerViewModel> Handle(GetOneEmployeerQuery request, CancellationToken cancellationToken)
        {
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            if (employeer == null)

                throw new Exception("Funcionario não está cadastrado !");


            return new EmployeerViewModel
            {
                Register = employeer.Register,
                Name = employeer.Name,
                Document = employeer.Document,
                BirthDate = employeer.BirthDate,
                Office = employeer.Office,
                LevelEmployeer = employeer.LevelEmployeer.ToString(),
            };
        }
    }
}
