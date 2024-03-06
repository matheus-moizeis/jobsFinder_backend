using JobsFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsFinder.Infrastructure.Database.Mapping;
public class CidadeMap : BaseMap<Cidade>
{
    public CidadeMap() : base("Cidade")
    {
    }

    public override void Configure(EntityTypeBuilder<Cidade> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.NomeCidade).HasMaxLength(50);
        builder.Property(x => x.CodIbge).HasMaxLength(5);
        builder.Property(x => x.EstadoId).IsRequired();
        builder.HasOne(x => x.Estado).WithMany(x => x.Cidades)
            .HasForeignKey(x => x.EstadoId);
    }
}
