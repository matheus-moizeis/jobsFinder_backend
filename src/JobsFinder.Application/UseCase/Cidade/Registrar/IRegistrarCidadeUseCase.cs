using JobsFinder.Communication.Request.Cidade;
using JobsFinder.Communication.Response.Cidade;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public interface IRegistrarCidadeUseCase
{
    Task<ResCidadeRegistradaJson> Executar(ReqResgitrarCidadeJson requisicao);
}
