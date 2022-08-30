using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;

namespace ProjectEntra21.src.Infrastructure.Database.Mappings
{
    public class EmployeerMapping : BaseMapping<Employeer>
    {
        public override string TableName => "Funcionario";

        protected override void MappingEntity(EntityTypeBuilder<Employeer> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Register });
            builder.Property(x => x.Name).IsRequired().HasColumnName("nome");
            builder.Property(x => x.Register).IsRequired().HasColumnName("matricula");
            builder.Property(x => x.BirthDate).IsRequired().HasColumnName("data_nascimento");
            builder.Property(x => x.Document).IsRequired().HasColumnName("documento");
            builder.Property(x => x.Office).IsRequired().HasColumnName("funcao");
            builder.Property(x => x.LevelEmployeer).IsRequired().HasColumnName("nivel_funcionario");
        }
    }
}
