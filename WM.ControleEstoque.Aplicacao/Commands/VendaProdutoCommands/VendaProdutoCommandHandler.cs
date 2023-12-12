using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.VendaProdutoCommands
{
    public class VendaProdutoCommandHandler : IRequestHandler<VendaProdutoCadastroCommand, VendaProdutoDto>
    {
        private readonly IUnitOfWork<Produto> _unitOfWorkProduto;
        private readonly IUnitOfWork<VendaProduto> _unitOfWorkVenda;

        public VendaProdutoCommandHandler(IUnitOfWork<VendaProduto> unitOfWorkVenda, IUnitOfWork<Produto> unitOfWorkProduto)
        {
            _unitOfWorkVenda = unitOfWorkVenda;
            _unitOfWorkProduto = unitOfWorkProduto;
        }

        public async Task<VendaProdutoDto> Handle(VendaProdutoCadastroCommand request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWorkProduto.ReadRepository.GetByIdAsync(request.ProdutoId);

            if (produto is null) return default!;

            var vendaProduto = _unitOfWorkVenda.WriteRepository.CreateAsync(VendaProduto.CadastroDeVenda(produto, request.QuantidadeVendida));

            if (vendaProduto is null) return default!;

            await _unitOfWorkVenda.SaveChangesAsync();

            return new VendaProdutoDto(vendaProduto.Id, vendaProduto.ProdutoId, vendaProduto.QuantidadeVendida, vendaProduto.ValorVendaTotal, vendaProduto.DataVenda);
        }
    }
}
