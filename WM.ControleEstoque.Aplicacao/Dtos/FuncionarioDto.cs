namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record FuncionarioDto(Guid Id, string Cpf,  string FuncionarioNome, string FuncionarioSenha, DateTime Datacadastro, Guid LojaId, Guid EnderecoId)
    { }
}
