using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.CategoriaQueries
{
    public class CategoriaListaQuery : IRequest<IEnumerable<CategoriaDto>> { }
}
