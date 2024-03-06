using AutoMapper;
using JobsFinder.Communication.Request;
using JobsFinder.Domain.Repository;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Exceptions;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade.Atualizar;
public class AtualizarCidadeUseCase : IAtualizarCidadeUseCase
{
    private readonly ICidadeUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public AtualizarCidadeUseCase(ICidadeUpdateOnlyRepository repository, IMapper mapper, IUnitOfWork uow)
    {
        _repository = repository;
        _mapper = mapper;
        _uow = uow;
    }

    public async Task Executar(long id, ReqResgitrarCidadeJson requisicao)
    {
        var cidade = await _repository.RecuperarPorId(id);

        Validar(cidade, requisicao);

        _mapper.Map(requisicao, cidade);

        _repository.Update(cidade);

        await _uow.Commit();
    }

    public static void Validar(Domain.Entities.Cidade cidade, ReqResgitrarCidadeJson requisicao)
    {
        if (cidade is null)
        {
            throw new ErrosDeValidacaoException(
            new List<string> { ResourceMensagensDeErro.Cidade_Nao_Encontrada });
        }
        var validator = new AtualizarCidadeValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagesDeErro = resultado.Errors.Select(
                c => c.ErrorMessage
                ).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
