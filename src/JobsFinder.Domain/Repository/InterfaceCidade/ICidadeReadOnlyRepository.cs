namespace JobsFinder.Domain.Repository.InterfaceCidade;
public interface ICidadeReadOnlyRepository
{
    Task<bool> ExisteCidade(string nomeCidade);
}
