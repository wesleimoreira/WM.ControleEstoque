namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record EnderecoDto(Guid Id, string Cep, string Pais, string Estado, string Cidade, string Bairro, string Rua, int Numero, string? Complemento)
    {
    }
}
