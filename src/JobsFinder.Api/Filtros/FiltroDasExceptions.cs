using JobsFinder.Communication.Response;
using JobsFinder.Exceptions;
using JobsFinder.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace JobsFinder.Api.Filtros;

public class FiltroDasExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JobsFinderException)
        {
            TratarJobsFinderException(context);
        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }

    private static void TratarJobsFinderException(ExceptionContext context)
    {
        if (context.Exception is ErrosDeValidacaoException)
        {
            TratarErrosDeValidacaoException(context);
        }
    }

    private static void TratarErrosDeValidacaoException(ExceptionContext context)
    {
        var erroValidacaoException = context.Exception as ErrosDeValidacaoException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ResErrorJson(erroValidacaoException.MensagensDeErro));
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResErrorJson(ResourceMensagensDeErro.Erro_Desconhecido));
    }
}
