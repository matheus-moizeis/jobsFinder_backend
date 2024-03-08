using JobsFinder.Domain.Entities;
using JobsFinder.Domain.Repository.InterfaceEstado;
using JobsFinder.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobsFinder.Infrastructure.Repository;
public class EstadoRepository : IEstadoRepository
{
    private readonly JobsFinderContext _context;
    public EstadoRepository(JobsFinderContext context)
    {
        _context = context;
    }

    public async Task<Estado> BuscaEstadoId(long id)
    {
        return await _context.Estados.FindAsync(id);
    }

    public async Task<Estado> BuscaIdEstadoUf(string Uf)
    {
        return await _context.Estados.AsNoTracking().FirstOrDefaultAsync(
            x => x.Uf == Uf.ToUpper()
            );
    }

    async Task<IEnumerable<Estado>> IEstadoRepository.BuscarTodosEstados()
    {
        return await _context.Estados.AsNoTracking().ToListAsync();
    }
}
