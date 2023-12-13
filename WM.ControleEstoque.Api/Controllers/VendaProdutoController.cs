using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.VendaProdutoCommands;
using WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/venda")]
    public class VendaProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendaProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterListaDeVendas()
        {
            try
            {
                return Ok(await _mediator.Send(new VendaProdutoListaQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }      

        [HttpPost]
        public async Task<IActionResult> CadastroDeVendas(VendaProdutoCadastroCommand command)
        {
            try
            {
                var venda =  await _mediator.Send(command);

                if (venda is null) return BadRequest();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
