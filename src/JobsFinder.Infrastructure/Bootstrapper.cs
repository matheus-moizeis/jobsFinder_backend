using JobsFinder.Domain.Extension;
using JobsFinder.Domain.Repository;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Domain.Repository.InterfaceEstado;
using JobsFinder.Infrastructure.Database;
using JobsFinder.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobsFinder.Infrastructure;
public static class Bootstrapper
{
    public static void AddRepositorio(this IServiceCollection services,
        IConfiguration configurationManager)
    {
        AddContext(services, configurationManager);
        AddUnitOfWord(services);
        AddRepositorios(services);
    } 

    private static void AddRepositorios(IServiceCollection services)
    {
        services.AddScoped<ICidadeWriteOnlyRepository, CidadeRepository>()
                .AddScoped<ICidadeReadOnlyRepository, CidadeRepository>()
                .AddScoped<ICidadeUpdateOnlyRepository, CidadeRepository>();

        services.AddScoped<IEstadoRepository, EstadoRepository>();
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConexaoCompleta();

        services.AddDbContext<JobsFinderContext>(dbContextoOpcoes =>
        {
            dbContextoOpcoes.UseNpgsql(conexao);
        });
    }

    private static void AddUnitOfWord(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
