using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class OrderMapping : BaseMapping<Order>
    {
        public override string TableName => "Ordem";

        protected override void MappingEntity(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Code });
            builder.Property(x => x.Code).IsRequired().HasColumnName("codigo_ordem");
            builder.Property(x => x.Data).IsRequired().HasColumnName("data_ordem").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.AmountEnter).IsRequired().HasColumnName("quantidade_entrada");
            builder.Property(x => x.AmountFinished).IsRequired().HasColumnName("quantidade_saida");
        }
    }
}