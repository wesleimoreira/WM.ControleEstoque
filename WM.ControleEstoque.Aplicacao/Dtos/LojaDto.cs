namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record LojaDto(Guid Id, string Cnpj, Guid EnderecoId, string RazaoSocial)
    { }
}
