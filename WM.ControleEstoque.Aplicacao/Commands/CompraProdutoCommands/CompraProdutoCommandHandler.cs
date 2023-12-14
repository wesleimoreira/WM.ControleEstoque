using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.CompraProdutoCommands
{
    public class CompraProdutoCommandHandler : IRequestHandler<CompraProdutoCadastroCommand, CompraProdutoDto>
    {
        private readonly IUnitOfWork<Produto> _unitOfWorkProduto;
        private readonly IUnitOfWork<CompraProduto> _unitOfWorkCompra;

        public CompraProdutoCommandHandler(IUnitOfWork<CompraProduto> unitOfWorkCompra, IUnitOfWork<Produto> unitOfWorkProduto)
        {
            _unitOfWorkCompra = unitOfWorkCompra;
            _unitOfWorkProduto = unitOfWorkProduto;
        }

        public async Task<CompraProdutoDto> Handle(CompraProdutoCadastroCommand request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWorkProduto.ReadRepository.GetByIdAsync(request.ProdutoId);

            if (produto is null) return default!;

            var compra = _unitOfWorkCompra.WriteRepository.CreateAsync(CompraProduto.CadastroDeCompraDeProdutos(produto, request.QuantidadeCompra));

            if(compra is null) return default!;

            await _unitOfWorkCompra.SaveChangesAsync();

            return new CompraProdutoDto(compra.Id,compra.Produto.Id, compra.Fornecedor.Id, compra.QuantidadeCompra, compra.ValorCompraTotal);
        }
    }
}
