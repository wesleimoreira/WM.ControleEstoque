using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.LojaQueries
{
    public class LojaListaQuery : IRequest<IEnumerable<LojaDto>>
    {
    }
}
