using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Products
{
    public class GetOneProductQuery : IRequest<ProductViewModel>
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag Type { get; set; }
    }

    public class GetOneProductRequestHandler : IRequestHandler<GetOneProductQuery, ProductViewModel>
    {
        private readonly IProductRepository _productRepository;

        public GetOneProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> Handle(GetOneProductQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.SelectOne(x => x.Code == request.Code);

            if (product == null) 
                return null;


            return new ProductViewModel
            {
                Code = product.Code,
                Name = product.Name,
                Type = product.Type.ToString(),
            };
        }
    }
}
