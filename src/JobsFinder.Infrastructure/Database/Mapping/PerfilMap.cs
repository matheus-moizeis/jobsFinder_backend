using JobsFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsFinder.Infrastructure.Database.Mapping;
public class PerfilMap : BaseMap<Perfil>
{
    public PerfilMap(string Perfil) : base(Perfil)
    {
    }
    public override void Configure(EntityTypeBuilder<Perfil> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome).HasMaxLength(20);
        builder.Property(x => x.Titulo).HasMaxLength(50);
        builder.Property(x => x.Sobrenome).HasMaxLength(100);
        builder.Property(x => x.Descricao).HasMaxLength(500);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.Telefone).HasMaxLength(15);
        builder.Property(x => x.DtNascimento).HasColumnType("datetime");
        builder.Property(x => x.Naturalidade).HasMaxLength(50);
        builder.Property(x => x.Nascionalidade).HasMaxLength(50);
        builder.Property(x => x.Linkedin).HasMaxLength(300);
        builder.Property(x => x.Site).HasMaxLength(300);
        builder.Property(x => x.Cep).HasMaxLength(8);
        builder.Property(x => x.Logradouro).HasMaxLength(100);
        builder.Property(x => x.Complemento).HasMaxLength(100);
        builder.Property(x => x.Bairro).HasMaxLength(50);
        builder.Property(x => x.CarteiraMotorista).HasMaxLength(50);
        builder.HasOne(x => x.Cidade).WithMany(x => x.Perfis)
            .HasForeignKey(x => x.IdCidade);
    }
}
