namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record VendaProdutoDto(Guid Id, Guid ProdutoId, int QuantidadeVendida, decimal ValorVendaTotal, DateTime DataVenda)
    {
    }
}