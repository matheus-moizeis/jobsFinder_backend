using JobsFinder.Domain.Entities;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobsFinder.Infrastructure.Repository;
public class CidadeRepository : ICidadeWriteOnlyRepository,
    ICidadeReadOnlyRepository,
    ICidadeUpdateOnlyRepository
{
    private readonly JobsFinderContext _context;

    public CidadeRepository(JobsFinderContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Cidade cidade)
    {
        await _context.Cidades.AddAsync(cidade);
    }

    public async Task<Cidade> BuscarCidadePorId(long id)
    {
        return await _context.Cidades
            .AsNoTracking()
            .Include(x => x.Estado)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Cidade>> BuscarCidadePorNome(string nome)
    {
        return await _context.Cidades
            .AsNoTracking()
            .Where(c => c.NomeCidade.Contains(nome))
            .Include(x => x.Estado)
            .ToListAsync();
    }

    public async Task<bool> ExisteCidadeIbge(int codIbge)
    {
        return await _context.Cidades.AnyAsync(
            c => c.CodIbge.Equals(codIbge));
    }

    public async Task<Cidade> RecuperarPorId(long cidadeId)
    {
        return await _context.Cidades.AsNoTracking()
            .Include(x => x.Estado)
            .FirstOrDefaultAsync(c => c.Id == cidadeId);
    }

    public async Task<IEnumerable<Cidade>> TodasAsCidades()
    {
        return await _context.Cidades
            .AsNoTracking()
            .Include(x => x.Estado)
            .ToListAsync();
    }

    public void Update(Cidade cidade)
    {
        _context.Update(cidade);
    }
}
