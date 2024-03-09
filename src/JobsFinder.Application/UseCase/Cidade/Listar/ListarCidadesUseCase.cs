using AutoMapper;
using JobsFinder.Communication.Response.Cidade;
using JobsFinder.Domain.Repository.InterfaceCidade;
using JobsFinder.Exceptions;
using JobsFinder.Exceptions.ExceptionBase;

namespace JobsFinder.Application.UseCase.Cidade.Listar;
public class ListarCidadesUseCase : IListarCidadesUseCase
{
    private readonly ICidadeReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public ListarCidadesUseCase(
        ICidadeReadOnlyRepository repository,
        IMapper mapper        
        )
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResCidadeRegistradaJson> CidadeId(long id)
    {
        Validar(id);

        var cidade = await _repository.BuscarCidadePorId(id);
        return _mapper.Map<ResCidadeRegistradaJson>(cidade);
    }

    public async Task<IEnumerable<ResCidadeRegistradaJson>> Cidades()
    {
        var cidades = await _repository.TodasAsCidades();

        return _mapper.Map<IEnumerable<ResCidadeRegistradaJson>>(cidades);

    }

    private void Validar(long cidadeId)
    {
        List<string> errors = new List<string>();

        if (!(cidadeId >= 0))
        {
            errors.Add(ResourceMensagensDeErro.Id_Obrigatorio);

            throw new ErrosDeValidacaoException(errors);
        }


    }
}
