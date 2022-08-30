using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Employeers
{
    public class PersistEmployeerCommand : IRequest<Employeer>
    {
        public long Register { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public string Office { get; set; }
        public string LevelEmployeer { get; set; }
    }

    public class PersistEmployeerCommandHandler : IRequestHandler<PersistEmployeerCommand, Employeer>
    {
        private readonly IEmployeerRepository _employeerRepository;

        public PersistEmployeerCommandHandler(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        public async Task<Employeer> Handle(PersistEmployeerCommand request, CancellationToken cancellationToken)
        {
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.Register);

            if (employeer == null)

                employeer = new Employeer();

            employeer.Name = request.Name;
            employeer.Document = request.Document;
            employeer.BirthDate = request.BirthDate;
            employeer.Office = request.Office;
            employeer.LevelEmployeer = Enum.Parse<LevelEmployeer>(request.LevelEmployeer);

            await _employeerRepository.InsertOrUpdate(employeer);

            return employeer;
        }
    }
}


