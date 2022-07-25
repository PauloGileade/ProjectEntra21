using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;

namespace ProjectEntra21.Infrastructure.Database.Mappings
{
    public class CellMapping : BaseMapping<Cell>
    {
        public override string TableName => "Celula";

        protected override void MappingEntity(EntityTypeBuilder<Cell> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.CodeCell });
            builder.Property(x => x.CodeCell).HasColumnName("codigo_celula");
            builder.Property(x => x.StatusCell).HasColumnName("status_celula");
        }
    }
}
