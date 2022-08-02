using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Employeers
{
    public class GetAllEmployeerQuery : IRequest<PaginationResponse<GetEmployeerViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllEmployeerQueryHandler : IRequestHandler<GetAllEmployeerQuery, PaginationResponse<GetEmployeerViewModel>>
    {
        private readonly IEmployeerRepository _employeerRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeerQueryHandler(IEmployeerRepository employeerRepository, IMapper mapper)
        {
            _employeerRepository = employeerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<GetEmployeerViewModel>> Handle(GetAllEmployeerQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _employeerRepository.SelectMore(request.Filters);

            var mappedItems = _mapper.Map<IEnumerable<GetEmployeerViewModel>>(queryResult.Data);

            return new PaginationResponse<GetEmployeerViewModel>(mappedItems, queryResult.CurrentPage, queryResult.TotalItems, queryResult.TotalPages);
        }
    }
}
