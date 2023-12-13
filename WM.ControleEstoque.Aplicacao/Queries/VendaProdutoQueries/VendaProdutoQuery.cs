using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries
{
    public class VendaProdutoListaQuery : IRequest<IEnumerable<VendaProdutoDto>>    {    }

   public class VendaProdutoHistoricoQuery: IRequest<IEnumerable<HistoricoDeComprasDto>> { }
}
