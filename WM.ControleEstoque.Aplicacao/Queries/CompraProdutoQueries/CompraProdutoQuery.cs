using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.CompraProdutoQueries
{
    public class CompraProdutoListaQuery : IRequest<IEnumerable<CompraProdutoDto>> { }

    public class CompraProdutoHistoricoQuery : IRequest<IEnumerable<HistoricoDeComprasDto>>
    {
        public CompraProdutoHistoricoQuery(DateTime? dataInicio, DateTime? dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime? DataFim { get; private set; }
        public DateTime? DataInicio { get; private set; }
    }
}
