using AutoMapper;
using JobsFinder.Communication.Request;
using JobsFinder.Domain.Repository;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public class RegistrarCidadeUseCase : IRegistrarCidadeUseCase
{
    private readonly ICidadeWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public RegistrarCidadeUseCase(ICidadeWriteOnlyRepository repository,
        IMapper mapper,
        IUnitOfWork uow)
    {
        _repository = repository;
        _mapper = mapper;
        _uow = uow;
    }

    public async Task Executar(ReqResgitrarCidadeJson requisicao)
    {
        Validate(requisicao);
        var entidade = _mapper.Map<Domain.Entities.Cidade>(requisicao);
        await _repository.Adicionar(entidade);
        await _uow.Commit();
    }

    private void Validate(ReqResgitrarCidadeJson requisicao)
    {
        var validator = new RegistrarCidadeValidator();
        var result = validator.Validate(requisicao);

        if (!result.IsValid)
        {
            var mensagensErro = result.Errors.Select
                (error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensErro);
        }
    }
}
