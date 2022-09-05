using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class CellEmployeerMapping : BaseMapping<CellEmployeer>
    {
        public override string TableName => "CelulaFuncionario";

        protected override void MappingEntity(EntityTypeBuilder<CellEmployeer> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Code});
            builder.Property(x => x.Code).IsRequired().HasColumnName("codigo");
            builder.Property(x => x.Phase).IsRequired().HasColumnName("Fase");
        }
    }
}
