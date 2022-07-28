using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Domain.Enums;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using ProjectEntra21.src.Application.Database;

namespace ProjectEntra21.src.Application.Request
{
    public class PersistEmployeerRequest : IRequest<Employeer>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Office { get; set; }
        public LevelEmployeer LevelEmployeer { get; set; }
    }

    public class PersistEmployeerRequestHandler : IRequestHandler<PersistEmployeerRequest, Employeer>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public PersistEmployeerRequestHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<Employeer> Handle(PersistEmployeerRequest request, CancellationToken cancellationToken)
        {
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Name == request.Name
                && x.Document == request.Document);

            if (employeer != null)

                return employeer;

            await _employeerRepository.Insert(new Employeer
            {
                Name = request.Name,
                Document = request.Document,
                BirthDate = request.BirthDate,
                Office = request.Office,
                LevelEmployeer = request.LevelEmployeer
            });

            return employeer;
        }
    }
}


