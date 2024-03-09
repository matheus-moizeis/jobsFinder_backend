using JobsFinder.Communication.Response.Cidade;

namespace JobsFinder.Application.UseCase.Cidade.Listar;
public interface IListarCidadesUseCase
{
    Task<IEnumerable<ResCidadeRegistradaJson>> Cidades();
    Task<ResCidadeRegistradaJson> CidadeId(long id);
}
