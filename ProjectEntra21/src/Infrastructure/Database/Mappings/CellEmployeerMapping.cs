using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class CellEmployeerMapping : BaseMapping<CellEmployeer>
    {
        public override string TableName => "CelulaFuncionario";

        protected override void MappingEntity(EntityTypeBuilder<CellEmployeer> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Code, x.RegisterEmployeer });
            builder.Property(x => x.Code).IsRequired().HasColumnName("codigo");
            builder.Property(x => x.RegisterEmployeer).IsRequired().HasColumnName("matricula_funcionario");
            builder.Property(x => x.CodeCell).IsRequired().HasColumnName("codigo_celula");
        }
    }
}
