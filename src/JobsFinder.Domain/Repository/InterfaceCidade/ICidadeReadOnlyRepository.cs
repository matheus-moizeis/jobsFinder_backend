namespace JobsFinder.Domain.Repository.InterfaceCidade;
public interface ICidadeReadOnlyRepository
{
    Task<bool> ExisteCidadeIbge(int codIbge);
}
