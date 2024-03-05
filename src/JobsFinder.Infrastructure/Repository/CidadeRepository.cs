using JobsFinder.Domain.Entities;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobsFinder.Infrastructure.Repository;
public class CidadeRepository : ICidadeWriteOnlyRepository,
    ICidadeReadOnlyRepository
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

    public async Task<bool> ExisteCidadeIbge(int codIbge)
    {
        return await _context.Cidades.AnyAsync(
            c => c.CodIbge.Equals(codIbge));
    }
}
