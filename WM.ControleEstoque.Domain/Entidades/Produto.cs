namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto(string produtoNome, int quantidadeEstoque, decimal produtoValorUnitario, Guid categoriaId, Guid fornecedorId)
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


        public static Produto CadastroDeProduto(string produtoNome, int quantidadeEstoque, decimal produtoValorUnitario, Guid categoriaId, Guid fornecedorId)
        {
            if (quantidadeEstoque.Equals(0)) return default!;

            if (string.IsNullOrWhiteSpace(produtoNome)) return default!;

            if (produtoValorUnitario.Equals(decimal.Zero)) return default!;

            if (string.IsNullOrWhiteSpace(categoriaId.ToString())) return default!;

            if (string.IsNullOrWhiteSpace(fornecedorId.ToString())) return default!;

            return new Produto(produtoNome, quantidadeEstoque, produtoValorUnitario, categoriaId, fornecedorId);
        }
    }
}
