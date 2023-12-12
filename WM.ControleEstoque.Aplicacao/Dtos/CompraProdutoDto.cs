namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record CompraProdutoDto(Guid Id, Guid ProdutoId, Guid FornecedorId, int QuantidadeCompra, decimal ValorCompraTotal)
    {
    }
}
