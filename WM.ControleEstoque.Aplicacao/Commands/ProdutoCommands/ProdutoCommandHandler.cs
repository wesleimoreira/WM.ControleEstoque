using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Infraestrutura.UnitOfWorks;

namespace WM.ControleEstoque.Aplicacao.Commands.ProdutoCommands
{
    public class ProdutoCommandHandler : IRequestHandler<ProdutoCadastroCommand, ProdutoDto>
    {
        private readonly UnitOfWork<Produto> _unitOfWork;

        public ProdutoCommandHandler(UnitOfWork<Produto> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoDto> Handle(ProdutoCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var produto =  _unitOfWork.WriteRepository.CreateAsync(
                Produto.CadastroDeProduto(request.ProdutoNome, request.QuantidadeEstoque, request.ProdutoValorUnitario, request.CategoriaId, request.FornecedorId));

            if (produto is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new ProdutoDto(produto.Id, produto.ProdutoNome, produto.QuantidadeEstoque, produto.ProdutoValorUnitario, produto.CategoriaId, produto.FornecedorId);
        }
    }
}
