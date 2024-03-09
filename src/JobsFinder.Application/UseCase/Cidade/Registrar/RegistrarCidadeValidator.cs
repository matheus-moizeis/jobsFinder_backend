using FluentValidation;
using JobsFinder.Communication.Request.Cidade;
using JobsFinder.Exceptions;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public class RegistrarCidadeValidator : AbstractValidator<ReqResgitrarCidadeJson>
{
    public RegistrarCidadeValidator()
    {
        RuleFor(x => x).SetValidator(new CidadeValidator());
    }
}
