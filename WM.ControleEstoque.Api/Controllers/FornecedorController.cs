using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.FornecedorCommands;
using WM.ControleEstoque.Aplicacao.Queries.FornecedorQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FornecedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterFornecedorPorId(Guid id)
        {
            try
            {
                var fornecedor = await _mediator.Send(new FornecedorPorIdQuery(id));

                if (fornecedor is null) return BadRequest();

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFornecedor(FornecedorCadastroCommand command)
        {
            try
            {
                var fornecedor = await _mediator.Send(command);

                if (fornecedor is null) return BadRequest();

                return CreatedAtAction(nameof(ObterFornecedorPorId), new { fornecedor.Id }, fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
