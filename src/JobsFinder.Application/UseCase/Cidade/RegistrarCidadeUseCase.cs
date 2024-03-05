using JobsFinder.Communication.Request;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade;
public class RegistrarCidadeUseCase
{
    public async Task Executar(ReqResgitrarCidadeJson requisicao)
    {
        Validate(requisicao); 
    }

    private void Validate(ReqResgitrarCidadeJson requisicao)
    {
        var validator = new RegistrarCidadeValidator();
        var result = validator.Validate(requisicao);
       
        if (!result.IsValid)
        {
            var mensagensErro = result.Errors.Select
                (error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensErro);
        }
    }
}
