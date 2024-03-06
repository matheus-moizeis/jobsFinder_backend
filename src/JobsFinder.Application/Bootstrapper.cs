using JobsFinder.Application.UseCase.Cidade.Atualizar;
using JobsFinder.Application.UseCase.Cidade.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace JobsFinder.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegistrarCidadeUseCase, RegistrarCidadeUseCase>();
        services.AddScoped<IAtualizarCidadeUseCase, AtualizarCidadeUseCase>();
    }
}
