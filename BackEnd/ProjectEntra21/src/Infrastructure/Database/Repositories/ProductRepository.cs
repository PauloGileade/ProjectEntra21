using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(Product product)
        {
            if (Dbset.Any(x => x.Code == product.Code))

                return Update(product);


            product.Code = NextCodeProduct();
            return Insert(product);
        }

        public long NextCodeProduct()
        {
            var newCode = Context.Products.Select(x => x.Code).OrderByDescending(x => x).FirstOrDefault();

            return newCode + 1;
        }
    }
}
