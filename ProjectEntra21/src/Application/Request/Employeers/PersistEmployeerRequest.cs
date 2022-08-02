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
            Employeer employeer = await _employeerRepository.SelectOne(x => x.Document == request.Document);

            if (employeer == null)

                employeer = new Employeer();

            employeer.Name = request.Name;
            employeer.Document = request.Document;
            employeer.BirthDate = request.BirthDate;
            employeer.Office = request.Office;
            employeer.LevelEmployeer = request.LevelEmployeer;

            await _employeerRepository.InsertOrUpdate(employeer);

            return employeer;
        }
    }
}


