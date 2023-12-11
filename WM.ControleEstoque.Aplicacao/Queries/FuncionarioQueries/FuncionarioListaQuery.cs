using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.FuncionarioQueries
{
    public class FuncionarioListaQuery : IRequest<IEnumerable<FuncionarioDto>>
    {
    }
}
