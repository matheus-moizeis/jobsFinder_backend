using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfacePerfil;
public interface IPerfilUpdateOnlyRepository
{
    Task<Perfil> RecuperarPorId(long id);
    void UpdatePerfil(Perfil perfil);
}
