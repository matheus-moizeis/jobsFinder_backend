using JobsFinder.Domain.Repository;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Exceptions;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade.Deletar;
public class DeletarCidadeUseCase : IDeletarCidadeUseCase
{
    private readonly ICidadeWriteOnlyRepository _repositoryWriteOnly;
    private readonly ICidadeReadOnlyRepository _repositoryReadOnly;
    private readonly IUnitOfWork _uow;

    public DeletarCidadeUseCase(ICidadeWriteOnlyRepository repositoryWriteOnly, ICidadeReadOnlyRepository repositoryReadOnly, IUnitOfWork uow)
    {
        _repositoryWriteOnly = repositoryWriteOnly;
        _repositoryReadOnly = repositoryReadOnly;
        _uow = uow;
    }


    public async Task Executar(long id)
    {
        var cidade = await _repositoryReadOnly.BuscarCidadePorId(id);

        Validar(cidade);

        await _repositoryWriteOnly.Deletar(id);

        await _uow.Commit();
    }

    public static void Validar(Domain.Entities.Cidade cidade)
    {
        if (cidade is null)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.Cidade_Nao_Encontrada });
        }
    }
}
