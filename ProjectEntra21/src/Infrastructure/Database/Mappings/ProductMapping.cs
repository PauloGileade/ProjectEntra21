using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class ProductMapping : BaseMapping<Product>
    {
        public override string TableName => "Produto";

        protected override void MappingEntity(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Code});
            builder.Property(x => x.Code).IsRequired().HasColumnName("codigo_produto");
            builder.Property(x => x.Name).IsRequired().HasColumnName("nome_produto");
            builder.Property(x => x.Type).IsRequired().HasColumnName("tipo_produto");
        }
    }
}