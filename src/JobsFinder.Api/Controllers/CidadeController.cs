using JobsFinder.Application.UseCase.Cidade.Atualizar;
using JobsFinder.Application.UseCase.Cidade.Registrar;
using JobsFinder.Communication.Request;
using JobsFinder.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsFinder.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CidadeController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResCidadeRegistradaJson),
        StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCidade(
        [FromServices] IRegistrarCidadeUseCase useCase,
        [FromBody] ReqResgitrarCidadeJson request)
    {
        var resultado = await useCase.Executar(request);

        return Created(string.Empty, resultado);

    }

    [HttpPut]
    [Route("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AtualizarCidade(
        [FromServices] IAtualizarCidadeUseCase useCase,
        [FromRoute] long id,
        [FromBody] ReqResgitrarCidadeJson requisicao)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }
}
