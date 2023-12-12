using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.VendaProdutoCommands
{
    public class VendaProdutoCadastroCommand : IRequest<VendaProdutoDto>
    {
        public VendaProdutoCadastroCommand(Guid produtoId, int quantidadeVendida, decimal valorVendaTotal)
        {
            ProdutoId = produtoId;
            DataVenda = DateTime.Now;
            ValorVendaTotal = valorVendaTotal;
            QuantidadeVendida = quantidadeVendida;
        }

        public Guid ProdutoId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public int QuantidadeVendida { get; private set; }
        public decimal ValorVendaTotal { get; private set; }
    }
}
