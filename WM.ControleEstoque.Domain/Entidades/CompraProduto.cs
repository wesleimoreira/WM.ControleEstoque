namespace WM.ControleEstoque.Dominio.Entidades
{
    public class CompraProduto : EntidadeBase
    {
        private CompraProduto(Guid produtoId, Guid fornecedorId, int quantidadeCompra, decimal valorCompraTotal)
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            DataDaCompra = DateTime.Now;
            QuantidadeCompra = quantidadeCompra;
            ValorCompraTotal = valorCompraTotal;
        }

        public Guid ProdutoId { get; private set; }
        public Guid FornecedorId { get; private set; }
        public int QuantidadeCompra { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public decimal ValorCompraTotal { get; private set; }


        public static CompraProduto CadastroDeCompraDeProdutos(Produto produto, Guid fornecedorId, int quantidadeCompra)
        {
            if (produto is null) return default!;

            if (quantidadeCompra.Equals(0)) return default!;

            if(string.IsNullOrWhiteSpace(fornecedorId.ToString())) return default!;

            return new CompraProduto(produto.Id, fornecedorId, quantidadeCompra, (produto.ProdutoValorUnitario * quantidadeCompra));
        }
    }
}
