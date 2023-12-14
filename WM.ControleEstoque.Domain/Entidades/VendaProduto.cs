namespace WM.ControleEstoque.Dominio.Entidades
{
    public class VendaProduto : EntidadeBase
    {
        private VendaProduto(int quantidadeVendida, decimal valorVendaTotal)
        {            
            DataVenda = DateTime.Now;
            ValorVendaTotal = valorVendaTotal;
            QuantidadeVendida = quantidadeVendida;
        }
  
        public  DateTime DataVenda { get; private set; }
        public int QuantidadeVendida {  get; private set; }
        public decimal ValorVendaTotal { get; private set; }

        // EF
        public Produto Produto { get; private set; } = default!;

        public static VendaProduto CadastroDeVenda(Produto produto, int quantidadeVendida)
        {
            if(produto is null) return default!;

            if (quantidadeVendida.Equals(0)) return default!;               

            return new VendaProduto(quantidadeVendida, (quantidadeVendida * produto.ProdutoValorUnitario));
        }
    }
}
