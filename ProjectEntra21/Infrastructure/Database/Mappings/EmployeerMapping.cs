using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;

namespace ProjectEntra21.Infrastructure.Database.Mappings
{
    public class EmployeerMapping : BaseMapping<Employeer>
    {
        public override string TableName => "Funcionario";

        protected override void MappingEntity(EntityTypeBuilder<Employeer> builder)
        {
            builder.ToTable(TableName);
            builder.HasAlternateKey(x => new { x.Register });
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Register).HasColumnName("matricula");
            builder.Property(x => x.BirthDate).HasColumnName("data_nascimento");
            builder.Property(x => x.Document).HasColumnName("documento");
            builder.Property(x => x.Office).HasColumnName("funcao");
            builder.Property(x => x.LevelEmployeer).HasColumnName("nivel_funcionario");
            builder.Property(x => x.CodeCell).HasColumnName("codigo_celula");
        }
    }
}
