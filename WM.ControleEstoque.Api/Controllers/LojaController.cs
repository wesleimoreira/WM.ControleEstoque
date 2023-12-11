using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.ControleEstoque.Aplicacao.Commands.LojaCommands;
using WM.ControleEstoque.Aplicacao.Queries.LojaQueries;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Api.Controllers
{
    [ApiController]
    [Route("v1/loja")]
    public class LojaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LojaController(IMediator mediator)
        {
            _mediator = mediator;
        }     

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLojaPorId(Guid id)
        {
            try
            {
                var loja = await _mediator.Send(new LojaPorIdQuery(id));

                if(loja is null) return NotFound();

                return Ok(loja);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLoja(LojaCadastroCommand command)
        {    
            try
            {
                var loja = await _mediator.Send(command);

                if (loja is null) return BadRequest();

                return CreatedAtAction(nameof(ObterLojaPorId), new { loja.Id}, loja);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
