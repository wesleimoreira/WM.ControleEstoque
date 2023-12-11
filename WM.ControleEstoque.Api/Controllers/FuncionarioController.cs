using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.FuncionarioCommands;
using WM.ControleEstoque.Aplicacao.Queries.FuncionarioQueries;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FuncionarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterFuncionarioPorId(Guid id)
        {
            try
            {
                var funcionario = await _mediator.Send(new FuncionarioPorIdQuery(id));

                if(funcionario is null) return NotFound();

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFuncionario(FuncionarioCadastroCommand command)
        {
            try
            {
                var funcionario = await _mediator.Send(command);

                if(funcionario is null) return BadRequest();

                return CreatedAtAction(nameof(ObterFuncionarioPorId), new { funcionario.Id }, funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
