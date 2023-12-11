using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.ProdutoQueries
{
    public class ProdutoListaQuery : IRequest<IEnumerable<ProdutoDto>>
    {
    }
}
