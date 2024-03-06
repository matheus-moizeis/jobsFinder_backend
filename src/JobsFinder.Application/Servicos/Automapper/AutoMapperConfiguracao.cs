using AutoMapper;
using JobsFinder.Communication.Request;
using JobsFinder.Communication.Response;
using JobsFinder.Domain.Entities;

namespace JobsFinder.Application.Servicos.Automapper;
public class AutoMapperConfiguracao : Profile
{
    public AutoMapperConfiguracao()
    {
        RequisicaoParaEntidade();
        EntidadeParaResposta();
    }

    private void RequisicaoParaEntidade()
    {
        CreateMap<ReqResgitrarCidadeJson,Cidade>();

    }

    private void EntidadeParaResposta()
    {
        CreateMap<Cidade, ResCidadeRegistradaJson>();
    }
}
