using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.CompraProdutoCommands;
using WM.ControleEstoque.Aplicacao.Queries.CompraProdutoQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/compra")]
    public class CompraProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompraProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTadasCompras( )
        {
            try
            {
                return Ok(await _mediator.Send(new CompraProdutoListaQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("periodo")]
        public async Task<IActionResult> ObterComprasPorPeriodo(CompraProdutoPorPeriodoQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastroDeCompraProduto(CompraProdutoCadastroCommand command)
        {
            try
            {
                var compra = await _mediator.Send(command);

                if (compra is null) return BadRequest();

                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
