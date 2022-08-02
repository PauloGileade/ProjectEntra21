using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Products
{
    public class PersistProductRequest : IRequest<Product>
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag Type { get; set; }
    }

    public class PersistProductResquestHandler : IRequestHandler<PersistProductRequest, Product>
    {
        private readonly IProductRepository _productRepository;

        public PersistProductResquestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(PersistProductRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.SelectOne(x => x.Code == request.Code);

            if (product == null)

                product = new Product();

            product.Name = request.Name;
            product.Type = request.Type;

            await _productRepository.InsertOrUpdate(product);

            return product;
        }
    }
}
