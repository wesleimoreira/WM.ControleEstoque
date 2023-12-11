namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record FornecedorDto(Guid Id, string FornecedorNome, string FornecedorTelefone, Guid EnderecoId)
    {
    }
}
