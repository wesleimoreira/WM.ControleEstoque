using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.CategoriaQueries
{
    public class CategoriaListaQuery : IRequest<IEnumerable<CategoriaDto>> { }

    public class CategoriaPorIdQuery : IRequest<CategoriaDto>
    {
        public CategoriaPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
