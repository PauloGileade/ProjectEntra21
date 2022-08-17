using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.CellEmployeers
{
    public class PersistCellEmployeerCommand : IRequest<CellEmployeer>
    {
        public int CodeCell { get; set; }
        public long RegisterEmployeer { get; set; }
    }

    public class PersistEmployeerCommandHandler : IRequestHandler<PersistCellEmployeerCommand, CellEmployeer>
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;
        private readonly ICellRepository _cellRepository;
        private readonly IEmployeerRepository _employeerRepository;

        public PersistEmployeerCommandHandler(ICellEmployeerRepository cellEmployeerRepository, ICellRepository cellRepository, IEmployeerRepository employeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
            _cellRepository = cellRepository;
            _employeerRepository = employeerRepository;

        }

        public async Task<CellEmployeer> Handle(PersistCellEmployeerCommand request, CancellationToken cancellationToken)
        {

            Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            if (cell == null)
                return null;

            Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.RegisterEmployeer);

            if (employeer == null)
                return null;



            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Employeer.Register == request.RegisterEmployeer
                 && x.CreateAt >= DateTime.Now.Date.Date
                    && x.CreateAt < DateTime.Now.Date.Date.AddDays(1)); ;

            if (cellEmployeer != null && cellEmployeer.CreateAt.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
            {

                cellEmployeer.Cell = cell;
                cellEmployeer.Employeer = employeer;

                await _cellEmployeerRepository.InsertOrUpdate(cellEmployeer);

                return cellEmployeer;
            }


            if (cellEmployeer == null)

                cellEmployeer = new CellEmployeer();

            cellEmployeer.Cell = cell;
            cellEmployeer.Employeer = employeer;

            await _cellEmployeerRepository.InsertOrUpdate(cellEmployeer);

            return cellEmployeer;
        }
    }
}
