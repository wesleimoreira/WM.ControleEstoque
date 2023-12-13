using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.ProdutoQueries
{
    public class ProdutoListaQuery : IRequest<IEnumerable<ProdutoDto>>
    { }
    public class ProdutoPorIdQuery : IRequest<ProdutoDto>
    {
        public ProdutoPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
