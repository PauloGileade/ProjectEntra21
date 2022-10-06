using AutoMapper;
using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace ProjectEntra21.src.Application.Query.Employeers
{
    public class GetAllEmployeerQuery : IRequest<PaginationResponse<EmployeerViewModel>>
    {
        public FilterBase Filters { get; set; }
    }

    public class GetAllEmployeerQueryHandler : IRequestHandler<GetAllEmployeerQuery, PaginationResponse<EmployeerViewModel>>
    {
        private readonly IEmployeerRepository _employeerRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeerQueryHandler(IEmployeerRepository employeerRepository, IMapper mapper)
        {
            _employeerRepository = employeerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<EmployeerViewModel>> Handle(GetAllEmployeerQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _employeerRepository.SelectAll(request.Filters);
            var mappedItems = _mapper.Map<IEnumerable<EmployeerViewModel>>(queryResult.Data);

            return new PaginationResponse<EmployeerViewModel>(mappedItems, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}
