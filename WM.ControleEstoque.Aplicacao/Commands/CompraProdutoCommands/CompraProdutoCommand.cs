using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.CompraProdutoCommands
{
    public class CompraProdutoCadastroCommand : IRequest<CompraProdutoDto>
    {
        public CompraProdutoCadastroCommand(Guid produtoId, Guid fornecedorId, int quantidadeCompra)
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            DataDaCompra = DateTime.Now;
            QuantidadeCompra = quantidadeCompra;
        }

        public Guid ProdutoId { get; private set; }
        public Guid FornecedorId { get; private set; }
        public int QuantidadeCompra { get; private set; }
        public DateTime DataDaCompra { get; private set; }
    }
}
