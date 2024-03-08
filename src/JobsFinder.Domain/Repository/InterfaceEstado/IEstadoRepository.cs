using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfaceEstado;
public interface IEstadoRepository
{
    Task<Estado> BuscaEstadoId(long id);
    Task<Estado> BuscaIdEstadoUf(string uf);
    Task<IEnumerable<Estado>> BuscarTodosEstados();
}
