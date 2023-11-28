using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaDeleteCommand : IRequest<CategoriaDto>
    {
        public CategoriaDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
