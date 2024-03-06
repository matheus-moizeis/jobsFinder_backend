using AutoMapper;
using JobsFinder.Communication.Response;
using JobsFinder.Domain.Repository.InterfaceEstado;
using JobsFinder.Exceptions.ExceptionBase;
using JobsFinder.Exceptions;

namespace JobsFinder.Application.UseCase.Estado.Buscar;
public class EstadoUseCase : IEstadoUseCase
{
    private readonly IEstadoRepository _estadoRepository;
    private readonly IMapper _mapper;

    public EstadoUseCase(IEstadoRepository estadoRepository, IMapper mapper)
    {
        _estadoRepository = estadoRepository;
        _mapper = mapper;
    }

    public async Task<ResponseEstado> BuscaEstadoId(long id)
    {
        if (id <= 0)
        {
            throw new ErrosDeValidacaoException(
                new List<string> { ResourceMensagensDeErro.Id_Obrigatorio }
                );
        }

        var estado = await _estadoRepository.BuscaEstadoId(id);

        Validar(estado);

        return _mapper.Map<ResponseEstado>(estado);
    }

    public async Task<ResponseEstado> BuscaIdEstadoUf(string uf)
    {
        if (string.IsNullOrEmpty(uf))
        {
            throw new ErrosDeValidacaoException(
                new List<string> { ResourceMensagensDeErro.Uf_Obrigatorio }
                );
        }
        
        var estado = await _estadoRepository.BuscaIdEstadoUf(uf);
        
        Validar(estado);

        return _mapper.Map<ResponseEstado>(estado);
    }

    public static void Validar(Domain.Entities.Estado estado)
    {
        if (estado is null)
        {
            throw new ErrosDeValidacaoException(
                new List<string> { ResourceMensagensDeErro.Estado_Nao_Encontrado }
                );
        }

    }
}
