using FluentValidation;
using JobsFinder.Communication.Request.Cidade;
using JobsFinder.Exceptions;

namespace JobsFinder.Application.UseCase.Cidade;
public class CidadeValidator : AbstractValidator<ReqResgitrarCidadeJson>
{
    public CidadeValidator()
    {
        RuleFor(x => x.NomeCidade)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Nome_Cidade_Vazia);

        RuleFor(x => x.CodIbge)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Ibge_Vazio);

        RuleFor(x => x.EstadoId)
         .NotEmpty()
         .WithMessage(ResourceMensagensDeErro.Estado_Vazio);
    }
}
