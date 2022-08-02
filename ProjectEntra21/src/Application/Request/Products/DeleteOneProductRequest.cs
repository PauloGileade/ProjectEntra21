using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Products
{
    public class DeleteOneProductRequest : IRequest
    {
        public long Code { get; set; }
    }

    public class DeleteOneProductRequestHandler : IRequestHandler<DeleteOneProductRequest>
    {
        private readonly IProductRepository _productRepository;

        public DeleteOneProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteOneProductRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _productRepository.SelectOne(x => x.Code == request.Code);

            await _productRepository.Delete(deleteProduct);

            return Unit.Value;
        }
    }
}
