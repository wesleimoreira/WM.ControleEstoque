namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Fornecedor : EntidadeBase
    {
        private Fornecedor(string fornecedorNome)
        {
            FornecedorNome = fornecedorNome;
        }

        public string FornecedorNome { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; } = default!; // EF
        public IEnumerable<CompraProduto> CompraProdutos { get; private set; } = default!; // EF

        public static Fornecedor CadastroDeFornecedor(string fornecedorNome)
        {
            if (string.IsNullOrWhiteSpace(fornecedorNome)) return default!;

            return new Fornecedor(fornecedorNome);
        }
    }
}
