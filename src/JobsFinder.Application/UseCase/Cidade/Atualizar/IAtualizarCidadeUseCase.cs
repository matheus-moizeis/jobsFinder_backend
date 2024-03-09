using JobsFinder.Communication.Request.Cidade;

namespace JobsFinder.Application.UseCase.Cidade.Atualizar;
public interface IAtualizarCidadeUseCase
{
    Task Executar(long id, ReqResgitrarCidadeJson requisicao);
}
