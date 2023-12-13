using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaCadastroCommand : IRequest<CategoriaDto>
    {
        public string CategoriaNome { get; set; } = default!;
    }

    public class CategoriaDeleteCommand : IRequest<CategoriaDto>
    {
        public CategoriaDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
