using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.TotalPartials
{
    public class GetOneTotalPartialQuery : IRequest<TotalPartialViewModel>
    {
        public PhaseCell Phase { get; set; }
        public long CodeCell { get; set; }
    }

    public class GetOneTotalPartialQueryHandler : IRequestHandler<GetOneTotalPartialQuery, TotalPartialViewModel>
    {

        private readonly ITotalPartialRepository _totalPartialRepository;

        public GetOneTotalPartialQueryHandler(ITotalPartialRepository totalPartialRepository)
        {
            _totalPartialRepository = totalPartialRepository;
        }

        public async Task<TotalPartialViewModel> Handle(GetOneTotalPartialQuery request, CancellationToken cancellationToken)
        {
            TotalPartial totalPartial = await _totalPartialRepository.SelectTotalPartialByPhase(request.Phase, request.CodeCell);

            if (totalPartial == null)
                return null;


            return new TotalPartialViewModel
            {
                CodeCell = totalPartial.Cell.CodeCell,
                Phase = totalPartial.Phase.ToString(),
                TotalPhaseExit = totalPartial.Total
            };
        }
    }
}
