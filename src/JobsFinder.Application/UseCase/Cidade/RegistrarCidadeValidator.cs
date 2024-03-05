using FluentValidation;
using JobsFinder.Communication.Request;
using JobsFinder.Exceptions;

namespace JobsFinder.Application.UseCase.Cidade;
public class RegistrarCidadeValidator : AbstractValidator<ReqResgitrarCidadeJson>
{
    public RegistrarCidadeValidator()
    {
        RuleFor(x => x.NomeCidade)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Nome_Cidade_Vazia);

        RuleFor(x => x.CodIbge)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Ibge_Vazio);

        RuleFor(x => x.IdEstado)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Estado_Vazio);
    }
}
