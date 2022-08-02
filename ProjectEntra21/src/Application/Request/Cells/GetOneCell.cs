using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Cells
{
    public class GetOneCell : IRequest<GetCellViewModel>
    {
        public int CodeCell { get; set; }
    }

    public class GetOneCellRequestHandler : IRequestHandler<GetOneCell, GetCellViewModel>
    {
        private readonly ICellRepository _cellRepository;

        public GetOneCellRequestHandler(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<GetCellViewModel> Handle(GetOneCell request, CancellationToken cancellationToken)
        {
            Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == request.CodeCell);

            return new GetCellViewModel
            {
                CodeCell = cell.CodeCell,
                StatusCell = cell.StatusCell,
            };
        }
    }
}
