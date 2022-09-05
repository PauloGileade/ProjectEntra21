using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class TotalPartialMapping : BaseMapping<TotalPartial>
    {
        public override string TableName => "TotalParcial";

        protected override void MappingEntity(EntityTypeBuilder<TotalPartial> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Id });
            builder.Property(x => x.Phase).IsRequired().HasColumnName("fase");
            builder.Property(x => x.Total).IsRequired().HasColumnName("total_saida");
        }
    }
}
