using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Cells
{
    public class GetOneCellQuery : IRequest<CellViewModel>
    {
        public int CodeCell { get; set; }
    }

    public class GetOneCellRequestHandler : IRequestHandler<GetOneCellQuery, CellViewModel>
    {
        private readonly ICellRepository _cellRepository;

        public GetOneCellRequestHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<CellViewModel> Handle(GetOneCellQuery request, CancellationToken cancellationToken)
        {
            Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            if (cell == null) 
                return null;

            return new CellViewModel
            {
                CodeCell = cell.CodeCell,
                StatusCell = cell.StatusCell.ToString(),
            };
        }
    }
}
