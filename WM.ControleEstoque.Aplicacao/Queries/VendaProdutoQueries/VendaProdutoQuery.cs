using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries
{
   public class VendaProdutoHistoricoQuery: IRequest<IEnumerable<HistoricoDeVendasDto>>
    {
        public VendaProdutoHistoricoQuery(DateTime? dataInicio, DateTime? dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime? DataFim { get; private set; }
        public DateTime? DataInicio { get; private set; }
    }
}
