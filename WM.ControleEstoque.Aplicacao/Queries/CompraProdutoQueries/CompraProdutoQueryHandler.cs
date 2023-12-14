using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.CompraProdutoQueries
{
    public class CompraProdutoQueryHandler : IRequestHandler<CompraProdutoHistoricoQuery, IEnumerable<HistoricoDeComprasDto>>
    {
        private readonly IUnitOfWork<CompraProduto> _unitOfWork;

        public CompraProdutoQueryHandler(IUnitOfWork<CompraProduto> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HistoricoDeComprasDto>> Handle(CompraProdutoHistoricoQuery request, CancellationToken cancellationToken)
        {
            var compras = await _unitOfWork.ReadRepository.GetAllAsync(nameof(Produto), nameof(Fornecedor));

            if (request.DataInicio.HasValue && request.DataFim.HasValue)
                return (from compra in compras
                        where compra.DataDaCompra.Date >= request.DataInicio.Value.Date || compra.DataDaCompra.Date <= request.DataFim.Value.Date
                        select new HistoricoDeComprasDto(compra.Produto.ProdutoNome, compra.QuantidadeCompra, compra.DataDaCompra, compra.Produto.ProdutoValorUnitario, compra.ValorCompraTotal, compra.Fornecedor.FornecedorNome, compra.Fornecedor.FornecedorTelefone)).ToList();

            return (from compra in compras
                    select new HistoricoDeComprasDto(compra.Produto.ProdutoNome, compra.QuantidadeCompra, compra.DataDaCompra, compra.Produto.ProdutoValorUnitario, compra.ValorCompraTotal, compra.Fornecedor.FornecedorNome, compra.Fornecedor.FornecedorTelefone)).ToList();
        }
    }
}
