using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.CompraProdutoQueries
{
    public class CompraProdutoQueryHandler :
        IRequestHandler<CompraProdutoListaQuery, IEnumerable<CompraProdutoDto>>,
        IRequestHandler<CompraProdutoHistoricoQuery, IEnumerable<HistoricoDeComprasDto>>
    {
        private readonly IUnitOfWork<CompraProduto> _unitOfWork;

        public CompraProdutoQueryHandler(IUnitOfWork<CompraProduto> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CompraProdutoDto>> Handle(CompraProdutoListaQuery request, CancellationToken cancellationToken)
        {
            var compras = await _unitOfWork.ReadRepository.GetAllAsync();

            return (from compra in compras
                    select new CompraProdutoDto(compra.Id, compra.ProdutoId, compra.FornecedorId, compra.QuantidadeCompra, compra.ValorCompraTotal)).ToList();
        }

        public Task<IEnumerable<HistoricoDeComprasDto>> Handle(CompraProdutoHistoricoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
