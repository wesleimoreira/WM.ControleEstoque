namespace WM.ControleEstoque.Dominio.Entidades
{
    public class VendaProduto : EntidadeBase
    {
        private VendaProduto(Guid produtoId, int quantidadeVendida, decimal valorVendaTotal)
        {
            ProdutoId = produtoId;
            DataVenda = DateTime.Now;
            ValorVendaTotal = valorVendaTotal;
            QuantidadeVendida = quantidadeVendida;
        }

        public Guid ProdutoId { get; private set; }
        public  DateTime DataVenda { get; private set; }
        public int QuantidadeVendida {  get; private set; }
        public decimal ValorVendaTotal { get; private set; }

        public static VendaProduto CadastroDeVenda(Produto produto, int quantidadeVendida)
        {
            if(produto is null) return default!;

            if (quantidadeVendida.Equals(0)) return default!;               

            return new VendaProduto(produto.Id, quantidadeVendida, (quantidadeVendida * produto.ProdutoValorUnitario));
        }
    }
}
