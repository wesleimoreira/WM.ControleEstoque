using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.EnderecoCommands;
using WM.ControleEstoque.Aplicacao.Queries.EnderecoQueries;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnderecoController(IMediator mediator) => _mediator = mediator;


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoPorId([FromRoute] Guid id)
        {
            var endereco = await _mediator.Send(new EnderecoPorIdQuery(id));

            if (endereco is null) return default!;

            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEndereco([FromBody] EnderecoCadastroCommand command)
        {
            try
            {
                var endereco = await _mediator.Send(command);

                if (endereco is null) return BadRequest();

                return CreatedAtAction(nameof(ObterEnderecoPorId), new { endereco.Id }, endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
