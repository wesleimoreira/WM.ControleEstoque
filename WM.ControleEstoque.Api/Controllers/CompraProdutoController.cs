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

        [HttpGet("historico/{dataInicio?}/{dataFim?}")]
        public async Task<IActionResult> ObterHistoricoDeCompras(DateTime? dataInicio, DateTime? dataFim)
        {
            try
            {
                return Ok(await _mediator.Send(new CompraProdutoHistoricoQuery(dataInicio, dataFim)));
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
