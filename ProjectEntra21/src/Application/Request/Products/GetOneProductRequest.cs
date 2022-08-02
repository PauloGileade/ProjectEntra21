using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Products
{
    public class GetOneProductRequest : IRequest<GetProductViewModel>
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag Type { get; set; }
    }

    public class GetOneProductRequestHandler : IRequestHandler<GetOneProductRequest, GetProductViewModel>
    {
        private readonly IProductRepository _productRepository;

        public GetOneProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductViewModel> Handle(GetOneProductRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.SelectOne(x => x.Code == request.Code);

            return new GetProductViewModel
            {
                Code = product.Code,
                Name = product.Name,
                Type = product.Type,
            };
        }
    }
}
