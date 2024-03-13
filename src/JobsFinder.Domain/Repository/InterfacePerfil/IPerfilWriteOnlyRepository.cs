using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfacePerfil;
public interface IPerfilWriteOnlyRepository
{
    Task Registrar(Perfil perfil);
    Task Deletar(long id);
}
