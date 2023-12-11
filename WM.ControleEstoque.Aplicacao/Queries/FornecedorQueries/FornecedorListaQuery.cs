using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.FornecedorQueries
{
    public class FornecedorListaQuery : IRequest<IEnumerable<FornecedorDto>>
    {

    }
}
