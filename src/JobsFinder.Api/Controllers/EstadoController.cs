using JobsFinder.Application.UseCase.Estado.Buscar;
using JobsFinder.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace JobsFinder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstadoController : ControllerBase
{
    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ResponseEstado),
    StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscaEstadoId(
        [FromServices] IEstadoUseCase useCase,
        [FromRoute] long id)
    {
        var estado = await useCase.BuscaEstadoId(id);
        return Ok(estado);
    }

    [HttpGet]
    [Route("uf/{uf}")]
    [ProducesResponseType(typeof(ResponseEstado),
    StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscaEstadoUf(
        [FromServices] IEstadoUseCase useCase,
        [FromRoute] string uf)
    {
        var estado = await useCase.BuscaIdEstadoUf(uf);
        return Ok(estado);
    }
}
