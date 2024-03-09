using AutoMapper;
using JobsFinder.Communication.Request.Cidade;
using JobsFinder.Communication.Response.Cidade;
using JobsFinder.Communication.Response.Estado;
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
        CreateMap<Estado, ResponseEstado>();        
    }
}
