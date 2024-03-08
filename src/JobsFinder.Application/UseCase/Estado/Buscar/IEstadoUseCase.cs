using JobsFinder.Communication.Response.Estado;

namespace JobsFinder.Application.UseCase.Estado.Buscar;
public interface IEstadoUseCase
{
    Task<ResponseEstado> BuscaEstadoId(long id);
    Task<ResponseEstado> BuscaIdEstadoUf(string uf);
    Task<IEnumerable<ResponseEstado>> BuscarTodosEstados();
}
