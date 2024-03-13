using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfacePerfil;
public interface IPerfilReadOnlyRepository
{
    Task<IEnumerable<Perfil>> RecuperarTodosPerfils();
    Task<Perfil> RecuperarPerfilPorId(long id);
}
