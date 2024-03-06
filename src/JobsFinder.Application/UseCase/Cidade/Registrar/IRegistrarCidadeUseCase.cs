using JobsFinder.Communication.Request;
using JobsFinder.Communication.Response;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public interface IRegistrarCidadeUseCase
{
    Task<ResCidadeRegistradaJson> Executar(ReqResgitrarCidadeJson requisicao);
}
