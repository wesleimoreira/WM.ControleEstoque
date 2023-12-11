namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record ProdutoDto(Guid Id, string ProdutoNome, int QuantidadeEstoque, decimal ProdutoValorUnitario, Guid CategoriaId, Guid FornecedorId)
    {
    }
}
