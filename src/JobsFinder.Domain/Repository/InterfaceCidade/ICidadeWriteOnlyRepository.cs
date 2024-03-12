using JobsFinder.Domain.Entities;

namespace JobsFinder.Domain.Repository.InterfaceCidade;
public interface ICidadeWriteOnlyRepository
{
    Task Adicionar(Cidade cidade);
    Task Deletar(long id);
}
