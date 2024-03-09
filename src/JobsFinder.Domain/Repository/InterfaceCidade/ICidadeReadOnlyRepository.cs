using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfaceCidade;
public interface ICidadeReadOnlyRepository
{
    Task<bool> ExisteCidadeIbge(int codIbge);
    Task<Cidade> BuscarCidadePorId(long id);
    Task<IEnumerable<Cidade>> TodasAsCidades();
    Task<IEnumerable<Cidade>> BuscarCidadePorNome(string nome);
}
