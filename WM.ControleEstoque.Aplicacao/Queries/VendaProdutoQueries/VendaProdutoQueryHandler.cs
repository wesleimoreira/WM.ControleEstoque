using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries
{
    public class VendaProdutoQueryHandler : IRequestHandler<VendaProdutoHistoricoQuery, IEnumerable<HistoricoDeVendasDto>>
    {
        private readonly IUnitOfWork<VendaProduto> _unitOfWork;

        public VendaProdutoQueryHandler(IUnitOfWork<VendaProduto> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HistoricoDeVendasDto>> Handle(VendaProdutoHistoricoQuery request, CancellationToken cancellationToken)
        {
            var vendas = await _unitOfWork.ReadRepository.GetAllAsync(nameof(Produto), null);

            if (request.DataInicio.HasValue && request.DataFim.HasValue)
                return (from venda in vendas
                        where venda.DataVenda.Date >= request.DataInicio.Value.Date || venda.DataVenda.Date <= request.DataFim.Value.Date
                        select new HistoricoDeVendasDto(venda.Produto.ProdutoNome, venda.Produto.ProdutoValorUnitario, venda.ValorVendaTotal, venda.DataVenda)).ToList();

            return (from venda in vendas
                    select new HistoricoDeVendasDto(venda.Produto.ProdutoNome, venda.Produto.ProdutoValorUnitario, venda.ValorVendaTotal, venda.DataVenda)).ToList();
        }
    }
}
