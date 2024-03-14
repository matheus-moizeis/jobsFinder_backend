using JobsFinder.Domain.Entities;
using JobsFinder.Domain.Repository.InterfacePerfil;
using JobsFinder.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobsFinder.Infrastructure.Repository;
public class PerfilRepository : IPerfilWriteOnlyRepository,
    IPerfilReadOnlyRepository,
    IPerfilUpdateOnlyRepository
{
    private readonly JobsFinderContext _context;

    public PerfilRepository(JobsFinderContext context)
    {
        _context = context;
    }

    public async Task Deletar(long id)
    {
        var perfil = await _context.Perfis
            .FirstOrDefaultAsync(x => x.Id == id);

        _context.Perfis.Remove(perfil);
    }

    public async Task<Perfil> RecuperarPerfilPorId(long id)
    {
        return await _context.Perfis
            .AsNoTracking()
            .Include(p => p.Cidade)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Perfil> RecuperarPorId(long id)
    {
        return await _context.Perfis
            .Include(p => p.Cidade)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Perfil>> RecuperarTodosPerfils()
    {
        return await _context.Perfis
            .AsNoTracking()
            .Include(p => p.Cidade)
            .ToListAsync();

    }

    public async Task Registrar(Perfil perfil)
    {
        await _context.Perfis.AddAsync(perfil);
    }

    public void UpdatePerfil(Perfil perfil)
    {
        _context.Perfis.Update(perfil);
    }
}
