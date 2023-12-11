using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands;
using WM.ControleEstoque.Aplicacao.Queries.CategoriaQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetCategoriasAsync()
        {
            try
            {
                return Ok(await _mediator.Send(new CategoriaListaQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaAsync([FromRoute] Guid id)
        {
            try
            {
                var categoriaResult = await _mediator.Send(new CategoriaPorIdQuery(id));

                if (categoriaResult is null) return NotFound();

                return Ok(categoriaResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaAsync([FromRoute] Guid id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString())) return BadRequest();

                var categoriaResult = await _mediator.Send(new CategoriaDeleteCommand(id));

                if (categoriaResult is null) return BadRequest();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoriaAsync([FromBody] CategoriaCadastroCommand command)
        {
            try
            {
                var categoriaResult = await _mediator.Send(command);

                if (categoriaResult is null) return BadRequest();

                return CreatedAtAction(nameof(GetCategoriaAsync), new { categoriaResult.Id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
