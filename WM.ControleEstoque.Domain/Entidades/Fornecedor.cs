namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Fornecedor : EntidadeBase
    {
        public Fornecedor(string fornecedorNome, string fornecedorTelefone, Guid enderecoId)
        {
            EnderecoId = enderecoId;
            FornecedorNome = fornecedorNome;
            FornecedorTelefone = fornecedorTelefone;
        }      

        public Guid EnderecoId { get; private set; }
        public string FornecedorNome { get; private set; }
        public string FornecedorTelefone { get; private set; }

        public IEnumerable<Produto> Produtos { get; private set; } = default!; // EF
        public IEnumerable<CompraProduto> CompraProdutos { get; private set; } = default!; // EF

        public static Fornecedor CadastroDeFornecedor(string fornecedorNome, string fornecedorTelefone, Guid enderecoId)
        {
            if (string.IsNullOrWhiteSpace(fornecedorNome)) return default!;

            if (string.IsNullOrWhiteSpace(fornecedorTelefone)) return default!;

            if (string.IsNullOrWhiteSpace(enderecoId.ToString())) return default!;

            return new Fornecedor(fornecedorNome, fornecedorTelefone, enderecoId);
        }
    }
}
