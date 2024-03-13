using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfacePerfil;
public interface IPerfilUpdateOnlyRepository
{
    void UpdatePerfil(Perfil perfil);
}
