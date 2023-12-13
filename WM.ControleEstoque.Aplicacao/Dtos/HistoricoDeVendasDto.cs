namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record HistoricoDeVendasDto(string NomeProduto, decimal ValorUnitarioProduto, decimal ValorTotalVenda, DateTime DataDaVenda)
    {
    }
}
