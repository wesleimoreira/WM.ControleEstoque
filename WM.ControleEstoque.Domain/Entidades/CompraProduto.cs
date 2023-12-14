namespace WM.ControleEstoque.Dominio.Entidades
{
    public class CompraProduto : EntidadeBase
    {
        private CompraProduto(int quantidadeCompra, decimal valorCompraTotal)
        {          
            DataDaCompra = DateTime.Now;
            QuantidadeCompra = quantidadeCompra;
            ValorCompraTotal = valorCompraTotal;
        }
       
        public int QuantidadeCompra { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public decimal ValorCompraTotal { get; private set; }

        // EF
        public Produto Produto { get; private set; } = default!;
        public Fornecedor Fornecedor { get; private set; } = default!;

        public static CompraProduto CadastroDeCompraDeProdutos(Produto produto, int quantidadeCompra)
        {
            if (produto is null) return default!;

            if (quantidadeCompra.Equals(0)) return default!;         

            return new CompraProduto(quantidadeCompra, (produto.ProdutoValorUnitario * quantidadeCompra));
        }
    }
}
