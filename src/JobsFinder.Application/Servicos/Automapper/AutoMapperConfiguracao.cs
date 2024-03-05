using AutoMapper;
using JobsFinder.Communication.Request;
using JobsFinder.Domain.Entities;

namespace JobsFinder.Application.Servicos.Automapper;
public class AutoMapperConfiguracao : Profile
{
    public AutoMapperConfiguracao()
    {
        CreateMap<Cidade, ReqResgitrarCidadeJson>().ReverseMap();
    }
}
