using JobsFinder.Application.UseCase.Cidade.Atualizar;
using JobsFinder.Application.UseCase.Cidade.Deletar;
using JobsFinder.Application.UseCase.Cidade.Listar;
using JobsFinder.Application.UseCase.Cidade.Registrar;
using JobsFinder.Communication.Request.Cidade;
using JobsFinder.Communication.Response.Cidade;
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

    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ResCidadeRegistradaJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarPorId(
        [FromServices] IListarCidadesUseCase useCase,
        [FromRoute] long id
        )
    {
        var cidade = await useCase.CidadeId(id);

        if (cidade == null) return NotFound();

        return Ok(cidade);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ResCidadeRegistradaJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodasAsCidades(
        [FromServices] IListarCidadesUseCase useCase)
    {
        var cidades = await useCase.Cidades();

        return Ok(cidades);
    }

    [HttpDelete]
    [Route("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deletar(
        [FromServices] IDeletarCidadeUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Executar(id);

        return NoContent();
    }
}
