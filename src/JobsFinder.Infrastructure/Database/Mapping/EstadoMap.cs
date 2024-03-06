using JobsFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsFinder.Infrastructure.Database.Mapping;
public class EstadoMap : BaseMap<Estado>
{
    public EstadoMap(string Estado) : base(Estado)
    {
    }

    public override void Configure(EntityTypeBuilder<Estado> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Uf).HasMaxLength(2);
        builder.Property(x => x.NomeEstado).HasMaxLength(40);
    }
}
