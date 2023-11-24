using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaCommand : IRequest<CategoriaDto>
    {
        public string CategoriaNome { get; set; } = default!;
    }
}
