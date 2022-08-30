using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Products
{
    public class DeleteOneProductCommand : IRequest
    {
        public long Code { get; set; }
    }

    public class DeleteOneProductCommandHandler : IRequestHandler<DeleteOneProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteOneProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteOneProductCommand request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _productRepository.SelectOne(x => x.Code == request.Code);

            await _productRepository.Delete(deleteProduct);

            return Unit.Value;
        }
    }
}
