using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Common;
using System;

namespace ProjectEntra21.src.Infrastructure.Database.Common
{
    public abstract class BaseMapping<T> : IBaseMapping where T : PatternEntity
    {
        public abstract string TableName { get; }

        public void Initialize(EntityTypeBuilder<T> builder)
        {
            MappingBase(builder);
            MappingPrimaryKey(builder);
            MappingEntity(builder);
        }

        protected abstract void MappingEntity(EntityTypeBuilder<T> builder);

        private void MappingPrimaryKey(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }

        private void MappingBase(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreateAt).HasColumnName("criado_em").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LastModifiedAt).HasColumnName("ultima_modificao_em").IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
