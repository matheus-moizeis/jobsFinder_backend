using JobsFinder.Communication.Request;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public interface IRegistrarCidadeUseCase
{
    Task Executar(ReqResgitrarCidadeJson requisicao);
}
