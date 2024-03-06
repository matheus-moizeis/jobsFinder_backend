using AutoMapper;
using JobsFinder.Communication.Request;
using JobsFinder.Communication.Response;
using JobsFinder.Domain.Repository;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Exceptions;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade.Registrar;
public class RegistrarCidadeUseCase : IRegistrarCidadeUseCase
{
    private readonly ICidadeReadOnlyRepository _respositoryRead;
    private readonly ICidadeWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public RegistrarCidadeUseCase(ICidadeWriteOnlyRepository repository,
        IMapper mapper,
        IUnitOfWork uow,
        ICidadeReadOnlyRepository respositoryRead)
    {
        _repository = repository;
        _mapper = mapper;
        _uow = uow;
        _respositoryRead = respositoryRead;
    }

    public async Task<ResCidadeRegistradaJson> Executar(ReqResgitrarCidadeJson requisicao)
    {
        await Validate(requisicao);
        var entidade = _mapper.Map<Domain.Entities.Cidade>(requisicao);
        await _repository.Adicionar(entidade);
        await _uow.Commit();

        return _mapper.Map<ResCidadeRegistradaJson>(entidade);
    }

    private async Task Validate(ReqResgitrarCidadeJson requisicao)
    {
        var validator = new RegistrarCidadeValidator();
        var result = validator.Validate(requisicao);

        var existeCidadeComIbge = await _respositoryRead.ExisteCidadeIbge(requisicao.CodIbge);

        if(existeCidadeComIbge)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("codIbge", ResourceMensagensDeErro.Ibge_Cadastrado));
        }

        if (!result.IsValid)
        {
            var mensagensErro = result.Errors.Select
                (error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensErro);
        }
    }
}
