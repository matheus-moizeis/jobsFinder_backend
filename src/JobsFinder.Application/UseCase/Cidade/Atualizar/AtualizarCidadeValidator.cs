using FluentValidation;
using JobsFinder.Communication.Request;

namespace JobsFinder.Application.UseCase.Cidade.Atualizar;
public class AtualizarCidadeValidator : AbstractValidator<ReqResgitrarCidadeJson>
{
    public AtualizarCidadeValidator()
    {
        RuleFor(x => x).SetValidator(new CidadeValidator());
    }
}
