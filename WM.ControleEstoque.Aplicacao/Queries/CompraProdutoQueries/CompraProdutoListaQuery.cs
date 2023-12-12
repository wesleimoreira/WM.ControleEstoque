using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.CompraProdutoQueries
{
    public class CompraProdutoListaQuery : IRequest<IEnumerable<CompraProdutoDto>>
    {
    }
}
