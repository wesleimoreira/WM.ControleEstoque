using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.Categoria
{
    public class CategoriaListaQuery : IRequest<IEnumerable<CategoriaDto>> { }
}
