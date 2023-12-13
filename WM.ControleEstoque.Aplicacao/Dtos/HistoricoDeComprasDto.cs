namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record HistoricoDeComprasDto(
        string NomeProduto,
        int QuantidadeCompra,
        DateTime DataCompra,
        decimal ValorUnitarioProduto,
        decimal ValorTotalCompra,
        string NomeFornecedor,
        string TelefoneFornecedor)
    { }
}
