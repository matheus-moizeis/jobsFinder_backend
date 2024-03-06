using JobsFinder.Communication.Request;

namespace JobsFinder.Application.UseCase.Cidade.Atualizar;
public interface IAtualizarCidadeUseCase
{
    Task Executar(long id, ReqResgitrarCidadeJson requisicao);
}
