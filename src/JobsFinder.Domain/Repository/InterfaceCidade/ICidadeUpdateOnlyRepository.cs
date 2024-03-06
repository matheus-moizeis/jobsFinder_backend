using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfaceCidade;
public interface ICidadeUpdateOnlyRepository
{
    Task<Cidade> RecuperarPorId(long id);
    void Update(Cidade cidade);
}
