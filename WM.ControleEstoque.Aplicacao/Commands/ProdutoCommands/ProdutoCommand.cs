using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.ProdutoCommands
{
    public class ProdutoCadastroCommand : IRequest<ProdutoDto>
    {
        public ProdutoCadastroCommand(string produtoNome, int quantidadeEstoque, decimal produtoValorUnitario, Guid categoriaId, Guid fornecedorId)
        {
            CategoriaId = categoriaId;
            ProdutoNome = produtoNome;
            FornecedorId = fornecedorId;
            DataCadastro = DateTime.Now;
            QuantidadeEstoque = quantidadeEstoque;
            ProdutoValorUnitario = produtoValorUnitario;
        }

        public Guid CategoriaId { get; private set; }
        public Guid FornecedorId { get; private set; }
        public string ProdutoNome { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public decimal ProdutoValorUnitario { get; private set; }
    }
}
