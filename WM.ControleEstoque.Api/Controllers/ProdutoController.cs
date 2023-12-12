using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.ProdutoCommands;
using WM.ControleEstoque.Aplicacao.Queries.ProdutoQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProdutoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            try
            {
                return Ok(await _mediator.Send(new ProdutoListaQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProdutoPorId(Guid id)
        {
            try
            {
                var produto = await _mediator.Send(new ProdutoPorIdQuery(id));

                if (produto is null) return BadRequest();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(ProdutoCadastroCommand command)
        {
            try
            {
                var produto = await _mediator.Send(command);

                if (produto is null) return BadRequest();

                return CreatedAtAction(nameof(ObterProdutoPorId), new { produto.Id }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
